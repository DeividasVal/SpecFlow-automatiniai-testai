@WS
Feature: Writeoff

@ignore
@TC165651
Scenario Outline: Writeoff document creation
    When user selects WriteoffWS
    And user presses add operation button
    And user enters document <Number>
    And user submits
    Then document <Number> is created successfuly

    Examples:
    | Number    |
    | Writeoff123 |

@ignore
@TC165652
Scenario: Writeoff adding item
    When user selects WriteoffWS
    And user presses add operation button
    And user enters document Writeoff123
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '2411111109876'
    And user submits
    Then item 111111 with quantity 1 is added successfuly
