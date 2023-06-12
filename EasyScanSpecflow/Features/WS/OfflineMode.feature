Feature: OfflineMode

offline mode for webserver
@ignore
Scenario: Price Check in Offline mode
	Given offline mode is on
	When user selects price checker
	Then user checks items by barcode and their values match:
	| Barcode     | Name          | Price | Stock |
	| B1100010030 | Rūbai B trend | 0.30  | 0     |
    And WIFI is turned back on

@ignore
Scenario: Check unknown item in Offline mode
	Given offline mode is on
    When user selects price checker
	And Plus button is pressed
    And Product code <Barcode> is entered and submitted
    Then app return message that item not found
    And WIFI is turned back on
    Examples:
    | Barcode |
    | 154516  |

@ignore
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
    And BarCodeWS is changed successfuly
    Examples:
    | NewBarcode | Barcode |  Number |
    | 2          | 1       | 22      |