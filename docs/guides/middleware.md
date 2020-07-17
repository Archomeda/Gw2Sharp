---
uid: Guides.Middleware
title: Middleware
---

# Using API middleware
Middleware can be used to change an API request before it's sent, or after it's been received.
As an example, by default Gw2Sharp uses middleware to support [caching](xref:Guides.Caching), [exception handling](xref:Guides.ExceptionHandling) and request splitting.
Keep in mind that this middleware is only supported for web API calls.
Render service calls do not use middleware.

You are free to configure the middleware as you like, however it's recommended to keep the default ones.
Accessing the list of middleware is done through the `Middleware` property in the `Connection` object.
This property is an `IList` and can be manipulated however you like.

```cs
var connection = new Gw2Sharp.Connection();
var middleware = connection.Middleware;
middleware.Add(newMiddlewareAtEnd);
middleware.Insert(0, newMiddlewareAtStart);
```

By default, `connection.Middleware` contains an instance of the following middleware in order:
- [`CacheMiddleware`](#cachemiddleware)
- [`RequestSplitterMiddleware`](#requestsplittermiddleware)
- [`ExceptionMiddleware`](#exceptionmiddleware)

## `CacheMiddleware`
This middleware is required if you want to use caching.
It's only one part of the caching requirement.
Check [the guide on caching](xref:Guides.Caching) for more information.

This middleware does not have any customizable configuration.

## `RequestSplitterMiddleware`
This middleware makes sure that any request that exceeds the maximum number of requested items in a bulk request, is split up in multiple smaller requests that the API can handle.
Effectively, this means that if you request 500 items in any endpoint client that supports bulk expansion (e.g. [`Gw2Client.WebApi.V2.Items`](../api/Gw2Sharp.WebApi.V2.Clients.ItemsClient.html)), this middleware splits your request up into 3 smaller requests (200, 200 and 100 items) and merges them together when it returns.

Currently, the requests are sent sequentially and not simultaneously.
The reason why there is no bursting feature, is that some endpoints contain so many items that by requesting all of them, you'll hit the rate limit extremely fast.
Because Gw2Sharp has no way to prevent this from happening at the moment (e.g. by artificially limiting requests client-sided or by listening to HTTP 429 responses), the request will most likely fail because of a very high chance of exceeding the rate limit with at least one splitted request.

This middleware supports configuring the maximum number of items per bulk request through the `MaxRequestSize` property. However, it's recommended to keep this at most 200, because the API will deny requests that exceed this number anyway.

## `ExceptionMiddleware`
This middleware checks the HTTP status codes and wraps possible errors in an exception that can be caught in your code.
Check [the guide on exception handling](xref:Guides.ExceptionHandling) for the kinds of exceptions that Gw2Sharp can throw.

This middleware does not have any customizable configuration.

---

## Implementing custom middleware
It's possible to implement your own middleware.
You do this by implementing the `IWebApiMiddleware` interface as follows:
```cs
public class CustomMiddleware : Gw2Sharp.WebApi.Middleware.IWebApiMiddleware
{
    public async Task<IWebApiResponse> OnRequestAsync(MiddlewareContext context, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken = default)
    {
        // Your pre-request logic here
        // If you desire, you can modify the context before sending it
        // to the next middleware
        // ...

        // Pass the execution to the next middleware in line
        var response = await callNext(context, cancellationToken);

        // Your post-request logic here
        // If you desire, you can modify the response before returning it
        // to the previous middleware
        // ...

        return response;
    }
}
```

After that, you'll need to add it to the list of middleware in the `Connection` instance:

```cs
// Assuming you already have a connection instance
var customMiddleware = new CustomMiddleware();
connection.Middleware.Add(customMiddleware);
```

Note that the order of the middleware in `connection.Middleware` is important.
The execution is from first to last pre-request, and from last to first post-request.
As an illustration:
```
    any request method, e.g. .GetAsync()
                     |
                     v
               middleware[0]
                     |
                     v
               middleware[1]
                     |
                     v
               middleware[2]
                     |
                     v
         executing web API request
                     |
                     v
               middleware[2]
                     |
                     v
               middleware[1]
                     |
                     v
               middleware[0]
                     |
                     v         
                  returns
```
