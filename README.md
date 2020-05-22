[![Build Status](https://dev.azure.com/OffTheRecordv4/OTRv4/_apis/build/status/southernsun.otr?branchName=master)](https://dev.azure.com/OffTheRecordv4/OTRv4/_build/latest?definitionId=1&branchName=master) <sub><sup>Azure DevOps</sup></sub>

[![Build Status](https://travis-ci.org/southernsun/otr.svg?branch=master)](https://travis-ci.org/southernsun/otr) <sub><sup>Travis-CI</sup></sub>

[![Coverage Status](https://coveralls.io/repos/github/southernsun/otr/badge.svg?branch=master)](https://coveralls.io/github/southernsun/otr?branch=master) <sub><sup>Coveralls</sup></sub>

[![CircleCI](https://circleci.com/gh/southernsun/otr.svg?style=shield)](https://circleci.com/gh/southernsun/otr) <sub><sup>CircleCI</sup></sub>

# Off the Record in C#

Purpose and intend: to develop a C# implementation of the Off The Record library that can be used cross platform.

Achieved by implementing in C# using .NET Core

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

