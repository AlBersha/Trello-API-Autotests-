Feature: Trello
    Kanban-based app for project management
    
@mytag
Scenario: Create new list
    Given the name of list is "Mobile app"
    And the board id is "5dd85a7f8f92ff62c8a4fcd8"
    When the function are executed
    Then the board is created    