Feature: OfflineMode

@TC176901
Scenario: Price Check in Offline mode
	Given offline mode is on
	When user selects price checker
	Then user checks items by barcode and their values match:
	| Barcode | Name                    | Price | Stock |
	| 1       | Virtos HOT DOG dešrelės | 0.00  | 0     |
    And WIFI is turned back on

@TC176902
Scenario: Check unknown item in Offline mode
	And offline mode is on
    When user selects price checker
	And Plus button is pressed
    And Product code <Barcode> is entered and submitted
    Then app return message that item not found
    And WIFI is turned back on
    Examples:
    | Barcode |
    | 1222    |

@TC176903
Scenario Outline: Barcode change with good item in Offline mode
    Given offline mode is on
    When user selects Barcode change
    And Plus button is pressed
    And Product code <Barcode> is entered and submitted
    And user presses change button
    And user enters new <NewBarcode> and document <Number>
    And user presses save
    And user syncs items
    Then user gets a message that can't sync in offline mode
    And WIFI is turned back on
    And user syncs items
    And BarCode is changed successfuly
    Examples:
    | NewBarcode | Barcode |  Number |
    | 2          | 1       | 22      |

@TC176904
Scenario: Code quantity check in stockadding in Offline mode
    Given offline mode is on
	When user selects stockadding
    And user presses add operation button
	And user enters document Adding123
	And user submits
	And user selects latest document
	And user submits items:
   | Barcode       |
   | 2305613000005 |
   | 1             |
    Then items with quantities are added: 
   | ExpectedQuantity | ExpectedBarcode |
   | 0                | 5613            |
   | 1                | 1               |
   And user syncs items
   And user gets a message that can't sync in offline mode
   And WIFI is turned back on
   And user syncs items
   And items are synced successfully

@TC176905
Scenario: Code quantity check in stocktaking in Offline mode
    Given offline mode is on
	When user selects stocktaking
    And user presses add operation button
	And user enters document Taking123
	And user submits
	And user selects latest document
	And user submits items:
   | Barcode       |
   | 2305613000005 |
   | 1             |
    Then items with quantities are added: 
   | ExpectedQuantity | ExpectedBarcode |
   | 0                | 5613            |
   | 1                | 1               |
   And user syncs items
   And user gets a message that can't sync in offline mode
   And WIFI is turned back on
   And user syncs items
   And items are synced successfully

@TC176906
Scenario: Code quantity check in write-off in Offline mode
    Given offline mode is on
	When user selects write-off
    And user presses add operation button
	And user enters document Write-off123
	And user submits
	And user selects latest document
	And user submits items:
   | Barcode       |
   | 2305613000005 |
   | 1             |
    Then items with quantities are added: 
   | ExpectedQuantity | ExpectedBarcode |
   | 0                | 5613            |
   | 1                | 1               |
   And user syncs items
   And user gets a message that can't sync in offline mode
   And WIFI is turned back on
   And user syncs items
   And items are synced successfully

@TC176907
Scenario: Delete item in stockadding in Offline mode
    Given user selects stockadding
    And document is selected and item is already added and synced
    And offline mode is on
    When user presses three dots near the item
    And user selects delete
    And user syncs items
    Then user gets a message that can't sync in offline mode
    And WIFI is turned back on
    And user syncs items
    And items are synced successfully
    And item is deleted and quantity changes to -quantity

@TC176908
Scenario: Delete item in stocktaking in Offline mode
    Given user selects stocktaking
    And document is selected and item is already added and synced
    And offline mode is on
    When user presses three dots near the item
    And user selects delete
    And user syncs items
    Then user gets a message that can't sync in offline mode
    And WIFI is turned back on
    And user syncs items
    And items are synced successfully
    And item is deleted and quantity changes to -quantity

@TC176909
Scenario: Delete item in write-off in Offline mode
    Given user selects write-off
    And document is selected and item is already added and synced
    And offline mode is on
    When user presses three dots near the item
    And user selects delete
    And user syncs items
    Then user gets a message that can't sync in offline mode
    And WIFI is turned back on
    And user syncs items
    And items are synced successfully
    And item is deleted and quantity changes to -quantity