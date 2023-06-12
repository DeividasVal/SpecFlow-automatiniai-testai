@WS
Feature: BarcodeChange

@ignore
@TC165673
Scenario Outline: Barcode change with good item
    When user selects Barcode change
    And Plus button is pressed
    And Product code <Barcode> is entered and submitted
    And user presses change button
    And user enters new <NewBarcode> and document <Number>
    And user presses save
    And user syncs items
    Then BarCode is changed successfuly
    Examples:
    | NewBarcode | Barcode |  Number |
    | 2          | 1       | 22      |
