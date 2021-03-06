# OTR

## Badges

### CircleCI

[![CircleCI](https://circleci.com/gh/southernsun/otr.svg?style=svg)](https://circleci.com/gh/southernsun/otr)

## Concept

This project is an OFF THE RECORD implementation using NET Core.

## Links

+ [ ] [CircleCI and NetCore](https://dev.to/herocod3r/setup-a-ci-cd-pipeline-for-net-core-with-circleci-292d)
bk: Not relevant? we have Azure Devops pipeline setup and previously travisci which we could re-enable again.

+ OTR implementation +/- 90% implemented as reference:
https://bugs.otr.im/otrv4/libotr-ng/-/tree/master/src

## Working On the project

If you have access to the repo and you cloned it.  These are tools and workflow suggestions.

### cbuteau

I use atom with the markdown preview enhanced
and visual studio community to code and debug.

This does not do plantuml...
https://marketplace.visualstudio.com/items?itemName=GitHub.GitHubExtensionforVisualStudio

## Outstanding tasks

https://github.com/southernsun/otr/projects/1

## Outstanding bugs / issues

https://github.com/southernsun/otr/issues

## References

+ [Crypto Libraries](./necessary_algo_libraries.md)
+ [Understanding](./understanding_otr.md)

## External references
+ The Legion of the Bouncy Castle - crypto library (https://www.bouncycastle.org/)
+ Crypto on Stackexchange - https://crypto.stackexchange.com/
+ MarkdownEditor - https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor


## Tools, frameworks and workflow suggestions

we will try to use:

Autofac - https://autofac.org/
~~+ Unity Container https://github.com/unitycontainer~~
+ Automapper - https://automapper.org/
+ Fluent Assertions - https://fluentassertions.com/
+ NUnit - https://nunit.org/

## Tools, frameworks and workflow for consideration

### State machine
staty - State machine
https://bitbucket.org/apacha/staty/src/master/

stateless - state machine
https://github.com/nblumhardt/stateless

## Random notes

### by southernsun:

BitConverter.IsLittleEndian;

## Links

+ [CircleCI NetCore tutorial](https://dev.to/herocod3r/setup-a-ci-cd-pipeline-for-net-core-with-circleci-292d)

## Planning
 + [x] Get Build going on CI (fan of circleci...suggest main author get initial build then provides access to me and others.) then running tests.
 
 bk: i had already setup azure devops pipeline. We can still consider circleci? I already had it running against travisci but removed that. see https://dev.azure.com/OffTheRecordv4/OTRv4/_build/results?buildId=21&view=ms.vss-test-web.build-test-results-tab
 Fine with azure pipelines but not familiar with debugging.
 
 + [ ] Is Code Coverage a priority...it is huge in javascriptland.
 
 bk: it is part of azure, we just need to push the results. i will look into this.
 
 + [ ] Planning for test app (Suggest Avalon)
 
 bk: will need to look into this... url?
