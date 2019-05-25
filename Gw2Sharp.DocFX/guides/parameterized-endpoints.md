---
uid: Guides.ParameterizedEndpoints
title: Accessing parameterized endpoints
---

# Accessing parameterized endpoints
Some endpoints require additional parameters, like `/v2/characters/:id` and `/v2/guild/:id`.
In order to make them intuitive and easily accessible, you can access them with the indexer.

An example for `/v2/characters/:id`:

```cs
// Assuming you already have a client

// The full list of characters
var characters = await client.V2.Characters.AllAsync();

// One character
var character = await client.V2.Characters["Your Character Name"].GetAsync();

// Accessing a subendpoint of a character
var specializations = await client.V2.Characters["Your Character Name"].Specializations.GetAsync();
```
