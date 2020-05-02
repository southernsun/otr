
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

+ compatible
  - means it handles OTRv3
+ interactive-only
  - Not sure.
+ standalone
  - Does its magic with DAKE.
