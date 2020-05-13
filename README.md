[![Build Status](https://dev.azure.com/OffTheRecordv4/OTRv4/_apis/build/status/southernsun.otr?branchName=master)](https://dev.azure.com/OffTheRecordv4/OTRv4/_build/latest?definitionId=1&branchName=master)

# Off the Record in C#

Purpose and intend: to develop a C# implementation of the Off The Record library that can be used cross platform.

Achieved by implementing in C# using .NET Standard and/or Core

**NOTE:** It will not support backward compatibility and just support OTR Protocol v4.
**NOTE2:** Although OTR recommends secure deletion of intermediate values and messages, 
this will not be supported in the initial version of this implementation, as current technology within the .NET (core) framework is limited and not guaranteed.
In other words, your local device should be kept secure. If your local device that runs OTR is compromised, your messages might be compromised.

# Resources

Official website: https://otr.cypherpunks.ca/

Mailinglist: https://lists.cypherpunks.ca/pipermail/otr-dev/2019-January/002564.html

draft specs for OTR v4: https://github.com/otrv4/otrv4
personal fork: https://github.com/southernsun/otrv4

# Task list

https://github.com/southernsun/otr/projects/1

