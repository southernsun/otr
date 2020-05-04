
# With DAKE.

```plantuml
Alice ---> Bob: Request OTR conversation
Alice <--> Bob: Establishes converation with DAKE
Alice <---> Bob: Exchange data messages.
```

So what is DAKE?
It stands for Deniable Key Exchange.

# Without DAKE

```plantuml
Alice <--- Bob: Client Profile
Alice <--- Bob: Prekey Profile
Alice <--- Bob: prekey messages

Alice --> Bob: Establish connection with XZDH

Alice <---> Bob: Exchange data messages.
```

## Modes

[NOT SUPPORTED] OTRv3-compatible mode: a mode with backwards compatibility with OTRv3. This mode will know how to handle plaintext messages, including query messages and whitespace tags.

OTRv4-standalone mode: an always encrypted mode. This mode will not know how to handle any kind of plaintext messages, including query messages and whitespace tags. It supports both interactive and non-interactive conversations. It is not backwards compatible with OTRv3.

OTRv4-interactive-only: an always encrypted mode that provides higher deniability properties when compared to the previous two modes, as it achieves offline and online deniability for both participants in a conversation. It only supports interactive conversations. It is not backwards compatible with OTRv3. This mode can be used by network models that do not have a central infrastructure, like Ricochet (keep in mind, though, that if OTRv4 is used over Ricochet [1], some online deniability properties will be lost).

1) https://ricochet.im/