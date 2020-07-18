---
uid: Guides.ExceptionHandling
title: Exception handling
---

# Exception handling
Gw2Sharp aims to be as friendly as possible when unexpected status codes are received from the Guild Wars 2 API.
Whenever a request fails, a custom exception will be thrown for you to catch.

The following exceptions can be thrown from Gw2Sharp:
- [`RequestException`](../api/Gw2Sharp.WebApi.Http.RequestException.html): An exception occured during the request
  - [`RequestCanceledException`](../api/Gw2Sharp.WebApi.Http.RequestCanceledException.html): The request has been canceled
  - [`UnexpectedStatusException`](../api/Gw2Sharp.WebApi.Http.UnexpectedStatusException.html): An unexpected HTTP status code was returned from the server
    - [`BadRequestException`](../api/Gw2Sharp.WebApi.Http.BadRequestException.html) (400): The client sent an invalid request
      - [`ListTooLongException`](../api/Gw2Sharp.WebApi.Http.ListTooLongException.html) (400): The list of requested resources is too long
      - [`PageOutOfRangeException`](../api/Gw2Sharp.WebApi.Http.PageOutOfRangeException.html) (400): The requested page is out of range
    - [`AuthorizationRequiredException`](../api/Gw2Sharp.WebApi.Http.AuthorizationRequiredException.html) (401, 403): The client is unauthorized
      - [`InvalidAccessTokenException`](../api/Gw2Sharp.WebApi.Http.InvalidAccessTokenException.html) (401, 403): The access token is invalid
      - [`MissingScopesException`](../api/Gw2Sharp.WebApi.Http.MissingScopesException.html) (403): The access token does not have the required scopes
      - [`MembershipRequiredException`](../api/Gw2Sharp.WebApi.Http.MembershipRequiredException.html) (403): The user is not a member of the guild
      - [`RestrictedToGuildLeadersException`](../api/Gw2Sharp.WebApi.Http.RestrictedToGuildLeadersException.html) (403): The user is not a leader of the guild
    - [`NotFoundException`](../api/Gw2Sharp.WebApi.Http.NotFoundException.html) (404): The requested resource has not been found
    - [`TooManyRequestsException`](../api/Gw2Sharp.WebApi.Http.TooManyRequestsException.html) (429): Too many requests have been issued in a short period of time
    - [`ServerErrorException`](../api/Gw2Sharp.WebApi.Http.ServerErrorException.html) (500): The server encountered an error
    - [`ServiceUnavailableException`](../api/Gw2Sharp.WebApi.Http.ServiceUnavailableException.html) (503): The server is temporarily unavailable

> [!TIP]
> As you can see, all custom exceptions inherit from `RequestException`.
> This makes it easier to have a generic catch-all statement for Gw2Sharp.
> However, certain exceptions may provide extra details as to why it has occured.
> If you need that information, it's recommended to catch the specific exceptions first, before the more generic ones.
