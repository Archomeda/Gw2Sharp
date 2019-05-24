---
uid: Guides.Subtokens
title: Creating and using subtokens
---

# Subtokens
Support for subtokens has been added to the API on May 20th, 2019.
You can read up on it [on the forums](https://en-forum.guildwars2.com/discussion/77211/api-update-may-20-2019).

On the outside, subtokens are just like the normal tokens, and can be used as such.
However, on the inside there's a big difference.
With subtokens, you can restrict the permissions based on scope and URL level.
Plus, you can also give it an expiry time.
As long as the subtoken permissions are a subset of the original token, you can do anything you want.

With Gw2Sharp, you can create a subtoken yourself with the following example:

```cs
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.V2.Models;

var connection = new Connection("your-original-token");
var client = new Gw2WebApiClient(connection);

// By using a fluent-design pattern, you can give it the parameters you want
var subtokenResponse = await client.V2.CreateSubtoken
    .WithPermissions(new[] { TokenPermission.Characters })
    .WithUrls(new[] { "/v2/characters" })
    .Expires(DateTime.Now.AddDays(1))
    .GetAsync();

// This token is now valid for 1 day, has the scope "characters" and can only access the /v2/characters API endpoint
var token = subtokenResponse.Subtoken;
```

And you can use this token with a new client, and it works the same as the previous client:

```cs
var subConnection = new Connection(token);
var subClient = new Gw2WebApiClient(subConnection);
```
