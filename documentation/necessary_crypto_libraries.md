- Ed448-Goldilocks
- SMPv2
- Diffie-Hellman ~128-bit security
- XSalsa20
- ChaCha20 - RFC 7539 

hash:
- SHAKE-256

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
Upgraded SHA-1 and SHA-2 to SHAKE-256.
Switched from AES to ChaCha20 [3]. The RFC 7539 variant is used [16] .
