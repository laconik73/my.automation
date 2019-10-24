@regression
@smoke

Feature: Login

Scenario:01. Verify Single-page application functionality
Given 'CPT' user is logged in
When 'CPT' user is logged in a new window
Then 'CPT' user is logged out from first window

