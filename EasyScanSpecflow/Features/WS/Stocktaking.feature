@WS
Feature: Stocktaking

@ignore
@TC165639
Scenario Outline: Stocktaking document creation
    When user selects stocktakingWS
    And user presses add operation button
    And user enters document <Number>
    And user submits
    Then document <Number> is created successfuly

    Examples:
    | Number    |
    | Taking123 |

@ignore
@TC165640
Scenario: Stocktaking adding item
    When user selects stocktakingWS
    And user presses add operation button
    And user enters document Taking123
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '2411111109876'
    And user submits
    Then item 111111 with quantity 1 is added successfuly