@WS
Feature: Stockadding

@ignore
@TC165643
Scenario Outline: Stockadding document creation
    When user selects stockadding
    And user presses add operation button
    And user enters document <Number>
    And user submits
    Then document <Number> is created successfuly

    Examples:
    | Number    |
    | Adding123 |

@ignore
@TC165644
Scenario: Stockadding adding item
    When user selects stockadding
    And user presses add operation button
    And user enters document Adding123
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '2411111109876'
    And user submits
    Then item 111111 with quantity 1 is added successfuly

#Scenario: Code quantity check in stockadding
#	When user selects stockadding
#    And user presses add operation button
#	And user enters document Adding123
#	And user submits
#	And user selects latest document
#	And user submits items:
#   | Barcode       |  
#   | 2311111100005 |  
#   | 2305613000025 |  
#   | 2305613000425 |  
#   | 2305613010005 |  
#   | 2305613015425 |  
#   | 2305613115425 |
#   | 2200001015425 |
#	Then items with quantities are added: 
#   | ExpectedQuantity | ExpectedBarcode  |
#   | 0                | 5613          |
#   | 0.002            | 5613          |
#   | 0.042            | 5613          |
#   | 1                | 5613          |
#   | 1.542            | 5613          |
#   | 11.542           | 5613          |
#   | 1542             | 1             |
#   And user syncs items
#   And items are synced successfully
    

# deletions not yet implemented in WS
#Scenario: Delete item in stockadding 
#    Given user selects stockadding
#    And document is selected and item is already added and synced
#    When user presses three dots near the item
#    And user selects delete
#    And user syncs items
#    Then items are synced successfully
#    And item is deleted and quantity changes to -quantity
#
#    
#Scenario: Reverse delete in stockadding
#    Given user selects stockadding
#    And document is selected and item is already deleted and synced
#    When user presses three dots near the item
#    And user selects delete
#    And user syncs items
#    Then items are synced successfully
#    And item is deleted and quantity changes to quantity without -
