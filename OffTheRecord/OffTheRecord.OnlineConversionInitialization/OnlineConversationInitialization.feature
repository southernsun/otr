Feature: OnlineConversationInitialization

Scenario: Requesting Conversation with Older OTR Versions
 Given Alice requests to start a conversation using OTRv3 by sending 'OTR?v3'
 When received by Bob
 Then the result be that the message is ignored