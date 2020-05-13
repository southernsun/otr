Necessary (crypto) algo's for OTR protocol v4:

| Name | Type | Available | Implemented | Source (library) | Used for | |
|---|---|---|---|---|---|---|
| Ed448-Goldilocks                              |               | unknown | no | - | |
| SMPv2                                         |               | unknown | no | - | |
| Diffie-Hellman ~128-bit security              |               | unknown | no | - | |
| XSalsa20                                      |               | unknown | no | - | |
| ChaCha20 based on RFC 7539                    |               | unknown | no | - | |
| Double Ratchet Algorithm                      |               | unknown | no | - | Key management |
| Deniable authenticated key exchanges (DAKE)   |               | unknown | no | - | |
| DAKE with Zero Knowledge (DAKEZ)              |               | unknown | no | - | |
| Extended Zero-knowledge Diffie-Hellman (XZDH) |               | unknown | no | - | |
| MAC Keys                                      |               | unknown | no | - | |
| SHAKE-256                                     | Hash algo.    | Yes | Yes  | BouncyCastle  | to hash the symmetric key, to make a hash from the public key fingerprint, hash the 'r' from the ECDH algo.  |
| Base64 Encoding                               | Encoding      | Yes | Yes  | .NET Core | encoding OTRv4 messages |
||||||


-- old/rough notes


Encryption:
- [ ] Ed448-Goldilocks
- [ ] SMPv2
- [ ] Diffie-Hellman ~128-bit security
- [ ] XSalsa20
- [ ] ChaCha20 - RFC 7539 

Hash:
- [x] SHAKE-256

Other:
- [x] Base64 encoding
- [.] RFC 8032 ?

In both the interactive and non-interactive DAKEs, OTRv4 uses long-term Ed448 keys, ephemeral Elliptic Curve Diffie-Hellman (ECDH) keys, and ephemeral Diffie-Hellman (DH) keys.

For exchanging data messages, OTRv4 uses KDF chains: the symmetric-key ratchet and the DH ratchet (with ECDH) from the Double Ratchet algorithm [2]. OTRv4 adds 3072-bit (384-byte) DH keys, called the brace key pair, to the Double Ratchet algorithm. These keys are used to protect transcripts of data messages in case ECC is broken. During the DAKE and initialization of the Double Ratchet Algorithm, both parties agree upon the first set of ECDH and DH keys. Then, during every third DH ratchet in the Double Ratchet, a new DH key is agreed upon. Between each DH brace key ratchet, both sides will conduct a symmetric brace key ratchet.

More information:

https://crypto.stackexchange.com/questions/44957/questions-about-sha-and-shake

https://keccak.team/index.html

available in https://github.com/bcgit/bc-csharp

https://www.nuget.org/packages/SHA3.Net/

https://www.nuget.org/packages/SHA3/1.0.0-rc

https://emn178.github.io/online-tools/shake_256.html


from documentation:
Updated cryptographic primitives and protocols:
Deniable authenticated key exchanges (DAKE) using "DAKE with Zero Knowledge" (DAKEZ) and "Extended Zero-knowledge Diffie-Hellman" (XZDH) [1]. DAKEZ corresponds to conversations when both parties are online (interactive) and XZDH to conversations when one of the parties is offline (non-interactive).
Key management using the Double Ratchet Algorithm [2].
Switched from AES to ChaCha20 [3]. The RFC 7539 variant is used [16] .

OTRv4 uses the Ed448-Goldilocks [4] elliptic curve [5]. Ed448-Goldilocks is an untwisted Edwards curve, where:

3072-bit Diffie-Hellman Parameters
For the Diffie-Hellman (DH) group computations, the group is the one defined in RFC 3526 [6] with a 3072-bit modulus (hex, big-endian):

OTRv4 public Ed448 forging key (ED448-FORGING-KEY):

OTRv4 public shared prekey (ED448-SHARED-PREKEY):

Socialist Millionaires Protocol (SMP)
