@WS
Feature: Adjustment

@ignore
@TC165629
Scenario Outline: Adjustment document creation
    When user selects adjustment
    And user presses add operation button
    And user enters document <Number>
    And user submits
    Then document <Number> is created successfuly
    Examples:
    | Number        |
    | Adjustment123 |

@ignore
@TC165630
Scenario: Adjustment adding item
    When user selects adjustment
    And user presses add operation button
    And user enters document Adjustment123
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '2411111109876'
    And user submits
    Then item 111111 with quantity 1 is added successfuly