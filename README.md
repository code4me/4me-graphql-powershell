# PowerShell Module for 4me GraphQL
A PowerShell Module for accessing the [4me GraphQL API](https://developer.4me.com/graphql/).

This module is compatible with both Windows PowerShell and PowerShell.

## Table of Contents
- [Licensing](#licensing)
- [PowerShell Gallery](#powershell-gallery)
- [Introduction](#introduction)
- [Client](#client)
- [Authentication](#authentication)
- [Querying](#querying)
  - [Filtering](#filtering)
  - [Views](#views)
  - [Pagination](#pagination)
  - [Date and Time Exceptions](#date-and-time-exceptions)
  - [Interface-based Properties](#interface-based-properties)
- [Mutations](#mutations)
- [Attachments](#attachments)
- [Events API](#events-api)
- [Bulk API](#bulk-api)
- [Multiple Clients](#multiple-clients)
- [Response Timing](#response-timing)
- [Verbose Output](#verbose-output)
- [Examples](#examples)
  - [Minimal example](#minimal-example)
  - [Authentication](#authentication-1)
  - [Queries](#queries)
  - [Mutations](#mutations-1)
  - [Attachments](#attachments-1)
  - [Events API](#events-api-1)
  - [Bulk API](#bulk-api-1)
  - [Multiple Clients](#multiple-clients-1)
  - [Verbose Output](#verbose-output-1)
- [Build Instruction](#build-instructions)
  
## Licensing
The PowerShell Module uses the [.NET SDK for 4me GraphQL](https://github.com/code4me/4me-sdk-graphql-dotnet) NuGet Package, which is a .NET SDK for accessing the [4me GraphQL API](https://developer.4me.com/graphql/).

## PowerShell Gallery
Stable binaries will be made available in the future through the [PowerShell Gallery](https://www.powershellgallery.com).

For [build instructions](#build-instructions), please refer to the end of this page.

## Introduction
The PowerShell Module simplifies the process of interacting with the 4me GraphQL API, allowing you to take full advantage of its query and mutation capabilities with ease. It abstracts away the complex task of managing low-level details such as sending requests, parsing responses, filtering, and pagination, making it simple to integrate 4me GraphQL API into your PowerShell scripts and fully leverage its functionalities.

For a general introduction to the GraphQL query language please see [graphql.org](https://graphql.org/), and for a 4me-specific introduction see [4me GraphQL Training](https://learning.4me.com/integrations_graphql/).

The data entities in the module are modeled after the 4me Quality Assurance GraphQL schema, which may include objects or properties that are not yet available in production.

## Client
The `Sdk4mePowerShellClient` object provides access to 4me GraphQL API for querying and modifying data and contains five properties that allow for default behavior customization:
- The `AccountID` property to update the 4me AccountID after initializing the `Sdk4mePowerShellClient`, allowing switching between accounts using the same client.
- The `EnumeratorTolerantSerializer` property, when set to true, allows for ignoring unmappable enumerator values and instead returns null or a default value.
- The `DefaultItemsPerRequest` property sets the number of items per connection request, with a default and maximum value of 100.
- The `MaximumRecursiveRequests` property controls the number of recursive requests that the client can make when pagination occurs in the top-level query. The default value is 10.
- The `MaximumQueryDepthLevelConnections` property controls the depth of nested queries. While it is possible to increase this limit, it can negatively affect performance. The default value is 2.

## Authentication
The module supports both Personal Access Token and OAuth 2.0 Client Credential Grant authentication methods.
It automatically renews the token 1 minute before it expires when using OAuth 2.0 Client Credential Grant.

## Querying
The module provides a simple and intuitive way to write queries, allowing you to easily retrieve the data you need.
The query properties also enable you to write nested queries, making it simple to work with related data.
You can execute complex queries and retrieve data with minimal effort, building efficient and performant scripts that leverage the full capabilities of the 4me GraphQL API.

### Filtering
Apply filters on root connections when creating a query, making it simple to retrieve specific data.
This feature allows you to limit the results returned by the query by adding conditions to the fields you are querying.
You can filter the results based on specific values or ranges, making it easy to find the data you need.

### Views
Specify the scope of your query by using the view argument on a root connection. The view argument allows you to target a specific set of data. By default, it is set to the current account, but it can also be used to query all accounts or another predefined subset of data for that specific data entity.

### Pagination
The underlying SDK takes care of pagination for you. The maximum number of items returned per connection is 100.
If your query returns more than 100 items on a connection, it will automatically retrieve the next 100 items without needing to write a new query, making it easy to work with large datasets.

### Date and Time Exceptions
The 4me GraphQL API has a data type called ISO8601Timestamp which includes three non-datetime values: `best_effort`, `no_target`, and `clock_stopped`, which cannot be converted to a standard date and time format.
The underlying SDK converts those values to specific date and time values:
- `best_effort` is converted to the date and time value of 0001-01-01 01:01:01.111
- `no_target` is converted to 0002-02-02 02:02:02.222
- `clock_stopped` is converted to 0003-03-03 03:03:03.333

### Interface-based Properties
Certain properties return objects that conform to an interface, providing flexibility in the variety of objects they can provide.
To obtain a specific object type from an interface-based property, it's crucial to indicate the desired type in the query statement of the query.
Without specifying a type in the query statement, the property will return null.

## Mutations
Mutations are used to create, update, or delete data. Like queries, the module provides a simple and intuitive way to perform mutations.

## Attachments
The module features a `Send-4meAttachment` method for uploading attachments, which can later be associated with any create or update mutation.
The response from this request can be used to create a `New-4meAttachment` object.
The response includes information necessary for linking these attachments.

## Events API
The module provides access to the 4me Events REST API. For more information, please visit the [4me developer pages](https://developer.4me.com/v1/requests/events/).

## Bulk API
The module also provides access to the 4me Bulk REST API, enabling data import and export. For more information, please visit the [4me developer pages](https://developer.4me.com/v1/bulk/).

## Multiple Clients
The module supports multiple client usage. Each CmdLet that invokes a query or mutation has a `Client` argument.
This can be used to connect to multiple 4me instances, or a single instance using multiple OAuth applications. A single token is limited to 3600 API requests per hour or 5000 points per hour for Query Cost. In some situations, this may not be sufficient. More information about [Rate Limiting](https://developer.4me.com/graphql/#request-rate-limits) and [Query Cost Limits](https://developer.4me.com/graphql/#query-cost-limit) can be found on the [4me developer website](https://developer.4me.com/graphql).

## Response Timing
The 4me GraphQL API limits the number of requests to 20 per 2 seconds.
The underlying SDK will keep track of the response time and lock the process to make sure it takes at least 100 milliseconds per request.

## Verbose Output
The module provides verbose output options to help with debugging and development.
This can be enabled using the `-Verbose` flag in your commands, providing detailed information about the operations being performed.

When verbose mode is enabled, each request produces two entries with identical identifiers:
- The initial entry contains the account ID, the HTTP verb, the URL, and the content of the request.
- The second entry includes the API response time in milliseconds.

These detailed entries can be helpful for debugging issues and auditing purposes, allowing you to see exactly what is being sent and received by the module.

# Examples

## Minimal example
```powershell
Import-Module ./Sdk4me.GraphQL.PowerShell

$connection = New-4meConnection -AccountID 'accountID' `
    -EnvironmentType Quality `
    -EnvironmentRegion EU `
    -PersonalAccessToken '***'

$meQuery = New-4meMeQuery -Properties ID,Name,PrimaryEmail
Invoke-4meMeQuery -Query $meQuery
```

## Authentication

### Personal Access Token
To authenticate using a personal access token, use the following command:
```powershell
$connection = New-4meConnection -AccountID 'accountID' `
    -EnvironmentType Quality `
    -EnvironmentRegion EU `
    -PersonalAccessToken '***'
```

### OAuth 2
To authenticate using OAuth 2, use the following command:
```powershell
$connection = New-4meConnection -AccountID 'accountID' `
    -EnvironmentType Quality `
    -EnvironmentRegion EU `
    -ClientID '3ukt.....kvsZdz' `
    -ClientSecret '***'
```

## Queries
Executing queries is always a two-step action: first creating a query and then invoking it.
This allows you to specify each field that needs to be returned for each object, as well as nested queries.
One of the great advantages of the GraphQL API is nested queries, which allow you to query not only a single object but also its related objects.
For example, you can query all people along with their assigned configuration items and related requests.

**Important**: Filters and views can only be used on root queries, not in sub-queries.

### Get People
This basic query retrieves people with their ID, primary email, name, and manager information.
```powershell
$personQuery = new-4mePersonQuery -Properties ID,PrimaryEmail,Name,Manager
Invoke-4mePersonQuery -Query $personQuery
```

### Get All People in the Directory and Support Domain Accounts
Use the view argument to specify the scope of the query.
```powershell
$personQuery = new-4mePersonQuery -Properties ID,PrimaryEmail,Name,Manager -View All
Invoke-4mePersonQuery -Query $personQuery
```

### Get All Service Instances
This example demonstrates how to fetch all service instances and format the output as a table displaying their ID, Name, and Status.
```powershell
$siQuery = New-4meServiceInstanceQuery -Properties ID,Name,Status
Invoke-4meServiceInstanceQuery $siQuery | Format-Table ID,Name,Status
```

### Nested Queries
This example demonstrates a nested query to fetch people along with their associated teams and their members, including the members' configuration items.
```powershell

$connection = New-4meConnection -AccountID 'accountID' `
    -EnvironmentType Quality `
    -EnvironmentRegion EU `
    -PersonalAccessToken '***' `
    -MaximumQueryDepthLevelConnections 4 `
    -DefaultItemsPerRequest 100

# Alternatively, you can set the properties after creating the connection:
# $connection.MaximumQueryDepthLevelConnections = 4
# $connection.DefaultItemsPerRequest = 100

$ciQuery = New-4meConfigurationItemQuery -Properties Name,Label,Status
$memberQuery = New-4mePersonQuery -Properties ID,Name -ConfigurationItems $ciQuery
$teamQuery = New-4meTeamQuery -Properties ID,Name -Members $memberQuery
$peopleQuery = New-4mePersonQuery -Properties Name,PrimaryEmail -Teams $teamQuery -ItemsPerRequest 10
Invoke-4mePersonQuery -Query $peopleQuery
```

#### Maximum Allowed Depth
The connection's `MaximumQueryDepthLevelConnections` property controls the depth of nested queries.
The example queries 4 levels deep, while the built-in default value is 2.
This means that the `MaximumQueryDepthLevelConnections` needs to be explicitly set for extensive nested queries.
While it is possible to increase this limit, doing so can affect performance when pagination applies on the `Members` their `ConfigurationItems`.

#### Items Per Request
The connection's `DefaultItemsPerRequest` property controls the default number of items per request used in every query.
The default value can be set when creating a new connection or via the `DefaultItemsPerRequest` property.

The default, and maximum, number of items per request is 100. The maximum number of items that can be returned in a single request with multiple connections is limited to 500,000.
When querying nested data, such as 100 people with 100 skill pools and 100 members each, the total number of items (100 x 100 x 100) exceeds the maximum of 500,000.
Therefore, specifying the number of items per request is important to avoid exceeding this limit.
In the example, the `ItemPerRequest` of `$peopleQuery` is set to 10.

### Filtering
This section demonstrates how to define and apply filters to your queries. Each root object allows one or more filters to be applied.

#### Filtering Configuration Items by Creation Date
This example demonstrates how to filter configuration items created in the last year.
```powershell
$ciQueryFilter = New-4meConfigurationItemQueryFilter -Property CreatedAt -Operator GreaterThan -DateTimeValues (Get-Date).AddYears(-1)
#ciQuery = New-4meConfigurationItemQuery -Properties Name,Label,Status -Filters $ciQueryFilter
Invoke-4meConfigurationItemQuery $ciQuery
```

#### Filtering People by Name and Disabled Status
This example shows how to define filters. Each root object allows one or more filters to be applied.
```powershell
$personQueryFilter1 = New-4mePersonQueryFilter -Property Name -Operator In -TextValues @('John','Jane')
$personQueryFilter2 = New-4mePersonQueryFilter -Property Disabled -Operator Equals -BooleanValue $false
$personQuery = new-4mePersonQuery -Properties ID,PrimaryEmail,Name -Filters @($personQueryFilter1,$personQueryFilter2)
Invoke-4mePersonQuery -Query $personQuery
```

#### Filtering Configuration Items by User Assignment and Status
This example demonstrates how to filter configuration items that are not assigned to any user and have a specific status.
```powershell
$ciQueryFilter1 = New-4meConfigurationItemQueryFilter -Property User -Operator Empty
$ciQueryFilter2 = New-4meConfigurationItemQueryFilter -Property Status -Operator In -TextValues @('in_stock','lent_out')
$ciQuery = New-4meConfigurationItemQuery -Properties Name,Label,Status -Filters @($ciQueryFilter1, $ciQueryFilter2)
Invoke-4meConfigurationItemQuery $ciQuery
```
When filtering using pre-defined values such as `CiStatus` and `RequestCategory`, you need to provide the underlying value, which is typically the snake_case version of the value.
For example, `In Stock` or `InStock` will be `in_stock`. All enumerators are listed on the [4me Developer pages](https://developer.4me.com/graphql/) in the section Enumerators.

#### Filtering Configuration Items by Status Using EnumMember
Using the underlying .NET GraphQL SDK, you can programmatically retrieve enum values, which is especially useful if you don't know the exact string literals or prefer a more dynamic approach.
This approach also auto completes the possible values, making it easier to select the correct value.
Here's how you can retrieve the enum value for `CiStatus.InStock`:
```powershell
$inStock = [Sdk4me.GraphQL.EnumExtension]::GetEnumMemberValue([Sdk4me.GraphQL.CiStatus]::InStock)
$ciQueryFilter = New-4meConfigurationItemQueryFilter -Property Status -Operator In -TextValues $inStock
$ciQuery = New-4meConfigurationItemQuery -Properties Name,Label,Status -Filters $ciQueryFilter
Invoke-4meConfigurationItemQuery $ciQuery | Format-Table Label,Name,Status
```
This method ensures that you always use the correct string value as defined in the SDK, reducing the risk of errors due to typos or changes in the enum definitions.

#### Filtering by ID
`ID` filtering allows you to search for an object based on its unique ID. When using the ID filter, any additional filters and view selections will be ignored.
It is recommended to use the ID filter instead of the `-Property ID -Operator Equals -TextValues 'ID value'` approach, as it provides an average response time improvement of approximately 15%.
The response will be a single request object and not an array.

```powershell
$requestQuery = New-4meRequestQuery -ID 'NG1lLnFhL1JlcS85MDI5NzE1' -Properties ID,Subject
Invoke-4meRequestQuery -Query $requestQuery
```

### Custom Fields
As custom fields can be of any type and contain any value, they are returned as `JToken` objects.
This means that the value will not be visible in the output unless explicitly casted.

#### Retrieving Custom Fields
The following example demonstrates how to retrieve and display the custom fields of a request.
```powershell
$requestFilter = new-4meRequestQueryFilter -Property ID -Operator Equals -TextValues 'NG1lLnFhL1JlcS8x'
$requestQuery = New-4meRequestQuery -Properties ID,CustomFields -Filters $requestFilter
$result = Invoke-4meRequestQuery -Query $requestQuery
```
```
PS C:\> $result[0].CustomFields
Value ID
----- --
{}    employee_id
{}    first_name
{}    last_name
{}    start_date
{}    organization
```

#### Casting Custom Field Values
To display the actual value of a custom field, you need to convert it to the correct type:
Convert the custom field value to a string:
```powershell
[string]$result[0].CustomFields['employee_id'].Value
```
Convert the custom field value to an integer:
```powershell
[int]$result[0].CustomFields['employee_id'].Value
```
Convert the custom field value to a DateTime:
```powershell
[DateTime]$result[0].CustomFields['start_date'].Value
```

#### Using Show-4meCustomFields Cmdlet
For a more user-friendly display of custom fields, you can use the `Show-4meCustomFields` cmdlet.
This cmdlet automatically converts all values to strings, simplifying the presentation of complex or varied data types.
```powershell
$requestFilter = new-4meRequestQueryFilter -Property ID -Operator Equals -TextValues 'NG1lLnFhL1JlcS8x'
$requestQuery = New-4meRequestQuery -Properties ID,CustomFields -Filters $requestFilter
$result = Invoke-4meRequestQuery -Query $requestQuery
$result[0] | Show-4meCustomFields -CustomFieldCollection { $_.CustomFields }
```
```
ID           Value
--           -----
employee_id  1
first_name   First
last_name    Last
start_date   2024-06-01
organization 
```

### Views
Views allow you to specify the scope of your query to target specific sets of data.
By default, a view is set to the current account, but you can use it to query all accounts or predefined subsets of data for a specific data entity.
Views can only be used on root queries, not in sub-queries.

#### Querying People Across All Accounts
This example demonstrates how to use a view to query people across all accounts.
```powershell
$personQuery = New-4mePersonQuery -Properties ID,PrimaryEmail,Name -View All
Invoke-4mePersonQuery -Query $personQuery
```

#### Get All Requests Assigned to Our Providers
This example shows how to use a view to retrieve all requests assigned to our providers.
```powershell
$requestQuery = New-4meRequestQuery -Properties ID,RequestId,Subject -View AssignedToOurProviders
Invoke-4meRequestQuery -Query $requestQuery
```

## Mutations
Mutations are used to create, update, or delete data, and they always apply to a single object.
With the exception of [Discovered Configuration Items](https://developer.4me.com/graphql/mutation/discoveredconfigurationitems/), which is not available via PowerShell, all mutations are single actions.
A create or update mutation always requires a definition of properties to be returned, similar to queries.

### Create a new person
This example demonstrates how to create a new person and return their ID.
```powershell
New-4mePerson -Name 'Welcome to PowerShell' `
    -OrganizationId 'NG1lLnFhL09yZ2FuaXphdGlvbi8yMzEyNjQ' `
    -PrimaryEmail 'welcometopowershell@example.com' `
    -Disabled $false -TimeFormat24h $true `
    -JobTitle 'Boss' `
    -Properties ID `
```

### Creating a person, including custom fields
This example demonstrates how to create a person with custom fields and return their ID and primary email.
```powershell
$hireDate = Get-Date -Year 2024 -Month 5 -Day 1
$customFields = New-4meCustomFieldCollection
$customFields = Add-4meCustomField -CustomFieldCollection $customFields -ID 'hire_date' -Value $hireDate
$customFields = Add-4meCustomField -CustomFieldCollection $customFields -ID 'contractor' -Value $true
$customFields = Add-4meCustomField -CustomFieldCollection $customFields -ID 'leave_date' -Value $null

New-4mePerson -Name 'Welcome to PowerShell' `
    -OrganizationId 'NG1lLnFhL09yZ2FuaXphdGlvbi8yMzEyNjQ' `
    -PrimaryEmail 'welcometopowershell@example.com' `
    -Disabled $false -TimeFormat24h $true `
    -JobTitle 'Boss' `
    -CustomFields $customFields `
    -Properties ID,PrimaryEmail
```

### Create a request
This example demonstrates how to create a new request with a subject and a note using a specific template and service instance, and then return the ID, RequestID, and Subject.
```powershell
New-4meRequest -Subject 'The subject' `
               -Note 'My note in **markdown**' `
               -TemplateId 'NG1lLnFhL3JlcXVlc3RfdGVtcGxhdGUvMTIz' `
               -Properties ID,RequestId,Subject
```

### Update a configuration item
This example demonstrates how to update an existing configuration item by changing the amount of memory and the remarks.
```powershell
Set-4meConfigurationItem -ID 'NG1lLnFhL0NpLzE4MjQ5MDU' -RamAmount 32.0 -Remarks 'Update via PowerShell' -Properties Label
```

### Update a person with custom fields
This example demonstrates how to create or update a custom field value of a person.
```powershell
$leaveDate = Get-Date -Year 2024 -Month 12 -Day 31
$customFields = Add-4meCustomField -CustomFieldCollection $customFields -ID 'leave_date' -Value $leaveDate

Set-4mePerson -CustomFields $customFields -Properties ID,PrimaryEmail
```

**Important**

Only the custom fields provided will be added or updated; all other non-specified custom fields remain unchanged.
Custom fields cannot be removed; once added, they can only be updated or set to `null`.
For example, if an object contains two custom fields, `start_date` and `leave_date`, and only the `start_date` is provided in an update, the `leave_date` remains untouched.

### Update a task
This example demonstrates how to assigned and complete a task with a note.
```powershell
$meQuery = New-4meMeQuery -Properties ID
$me = Invoke-4meMeQuery -Query $meQuery
Set-4meTask -ID 'NG1lLnFhL1Rhc2svNTM3ODAyMg' `
    -Note 'Completed. Do **NOT** reboot our database server during business hours.' `
    -Status Completed `
    -MemberId $me.ID `
    -Properties ID,Status
```

### Delete a Webhook
This example demonstrates how to delete a webhook.
```powershell
$webhookPolicyQuery = New-4meWebhookPolicyQuery -Properties ID,CreatedAt
$webhookPolicies = Invoke-4meWebhookPolicyQuery -Query $webhookPolicyQuery
$webhookPolicies | Format-Table ID,CreatedAt

$result = Remove-4meWebhookPolicy -ID 'NG1lLnFhL1dlYmhvb2tQb2xpY3kvMQ'
```

## Attachments
Uploading an attachment is a three-step process
- Upload the attachment
- Create an attachment input object
- Add it to any object supporting attachments by referencing the attachment input object

### Add a Note With an Attachment
Upload the `HelloWorld.txt` file and add it to the request.
```powershell
$requestQuery = New-4meRequestQuery -ID 'NG1lLnFhL1JlcS85MDI5NzE1' -Properties ID,Subject
$request = Invoke-4meRequestQuery -Query $requestQuery
$attachmentUpload = Send-4meAttachment -Path '.\HelloWorld.txt' -ContentType 'text/plain'
$attachment = New-4meAttachment -Key $attachmentUpload.Key -Inline $false
New-4meNote -OwnerId $request.ID -Text 'Please review the attached document' -Attachments $attachment -Properties ID
```

### Add a Note With an Embedded Attachment
Upload the `image.png` file and add it to the request.
```powershell
$requestQuery = New-4meRequestQuery -ID 'NG1lLnFhL1JlcS85MDI5NzE1' -Properties ID,Subject
$request = Invoke-4meRequestQuery -Query $requestQuery
$attachmentUpload = Send-4meAttachment -Path '.\image.png' -ContentType 'image/png'
$attachment = New-4meAttachment -Key $attachmentUpload.Key -Inline $true
New-4meNote -OwnerId $request.ID -Text "This is an embedded image.`n![]($($attachment.Key))" -Attachments $attachment -Properties ID
```

### Non-Embedded Attachments
In the case of a non-embedded attachment, a direct reference to the `$attachmentUpload` can be used.
```powershell
$attachmentUpload = Send-4meAttachment -Path '.\HelloWorld.txt' -ContentType 'text/plain'
New-4meNote -OwnerId $request.ID -Text 'Please review the attached document' -Attachments $attachmentUpload.Key -Properties ID
```

In these examples, the process for adding attachments to a request involves first uploading the file, then creating an attachment input object, and finally adding the attachment to the note associated with the request.
Embedded attachments are shown with an inline image in the note text, while non-embedded attachments are referenced directly.

## Events API
Create a request using the 4me Events API.

### Example
This example demonstrates how to create a new request using the Events API.
```powershell
$hostname = hostname
New-4meEvent -Category Incident `
    -Note 'Something went wrong.' `
    -Subject 'System Error' `
    -Source 'Monitoring' `
    -SourceID $hostname `
    -ServiceInstanceName 'Desktop support' `
    -Impact Medium `
    -TeamName 'Service desk'
```

## Bulk API
Import and export data using the 4me Bulk API.
For detailed information about the Bulk API, please check the [4me developer pages](https://developer.4me.com/v1/bulk/).

The import and export CmdLets contains a `PollingInterval` and `Timeout` property.

The `PollingInterval` is the time in seconds between the status queries. Be mindful of the API rate limit when setting the polling interval.

The `Timeout` is optional and specifies the time in seconds before the operation should be cancelled.

### Export a Single Data Type

The following script demonstrates how to get all configuration items, wait for the export to complete, and save the file.
```powershell
$token = Start-4meDataExport -Format CSV -Types @('cis')
Save-4meDataExport -Token $token -Path 'c:\temp\cis.csv' -PollingInterval 15
```

### Export a Single Data Type and Save as XLSX
This script exports the same data as the previous example but as an Excel file instead of CSV.
```powershell
$token = Start-4meDataExport -Format Excel -Types @('cis')
Save-4meDataExport -Token $token -Path 'c:\temp\cis.xlsx' -PollingInterval 15
```

### Export Multiple Data Types
The following script demonstrates how to get all configuration items and people that were updated in the last 7 days, wait for the export to complete, and save the file.
The `From` value is optional and limited to 2 months back in time.
```powershell
$date = (Get-Date).AddDays(-7)
$token = Start-4meDataExport -Format CSV -Types @('cis','people') -From $date
Save-4meDataExport -Token $token -Path '.\cis_people.zip' -LineSeparator CarriageReturnLineFeed -PollingInterval 15 -Timeout 900
```

### Create or Update Configurations Items via Import
Use the Bulk Import API to update a set of configuration items.
```powershell
$token = Start-4meDataImport -Path 'C:\temp\4me_cis_import.csv' -Type 'cis'
$result = Wait-4meDataImport -Token $token -PollingInterval 15 -Timeout 300
```
The `$result` object contains the response of a completed or failed import.

```
PS C:\> $result

State   : Done
Line    :
Message :
Results : Sdk4me.GraphQL.ImportResults
LogFile : ...
```
The `$result.Results` property contains the summary of changes.
```
PS C:\> $result.Results

Created   : 0
Updated   : 1
Deleted   : 0
Unchanged : 0
Failures  : 0
Errors    : 0
```

## Multiple Clients
Each CmdLet that invokes a query or mutation has a `Client` argument.

### Example
```powershell
$connections = @{
    "Support-Domain-1" = New-4meConnection -AccountID 'Support-Domain-1' -EnvironmentType Quality -EnvironmentRegion EU -PersonalAccessToken '***'
    "Support-Domain-2" = New-4meConnection -AccountID 'Support-Domain-2' -EnvironmentType Production -EnvironmentRegion EU -PersonalAccessToken '***'
    "DA" = New-4meConnection -AccountID 'DA' -EnvironmentType Quality -EnvironmentRegion EU -PersonalAccessToken '***'
}

$meQuery = New-4meMeQuery -Properties ID,Name,PrimaryEmail
$me = Invoke-4meMeQuery -Query $meQuery -Client $connections["DA"]

$forQuery = New-4mePersonQuery -ID 'NG1lLnFhL1BlcnNvbi8zMjI0MTU4' -Properties ID,Name
$for = Invoke-4mePersonQuery -Query $forQuery -Client $connections["DA"]

$request = New-4meRequest `
    -Subject 'Subject' `
    -Note 'My note in **markdown**' `
    -TemplateId 'NG1lLnFhL3JlcXVlc3RfdGVtcGxhdGUvMTIz' `
    -RequestedForId $for.ID `
    -Properties RequestId `
    -Client $connections["Support-Domain-1"]

Write-Host "Request `#$($request.RequestId) was created for $($for.Name)"
```

## Verbose Output
When verbose mode is enabled, it will show all parameters and provide detailed information when calling the 4me GraphQL API. Each verbose output will contain two entries:
- The initial entry contains the account ID, HTTP verb, URL, and content of the request.
- The second entry includes the API response time in milliseconds.

### Example
```powershell
$connection = New-4meConnection -AccountID 'accountID' -EnvironmentType Quality -EnvironmentRegion EU -PersonalAccessToken '***' -Verbose
```
```
VERBOSE: [2024-07-29T01:48:42.644+02:00] [New-4meConnection] Start
VERBOSE: [2024-07-29T01:48:42.647+02:00] [New-4meConnection] Parameter: AccountID | Value: account-id
VERBOSE: [2024-07-29T01:48:42.647+02:00] [New-4meConnection] Parameter: EnvironmentType | Value: Quality
VERBOSE: [2024-07-29T01:48:42.647+02:00] [New-4meConnection] Parameter: EnvironmentRegion | Value: EU
VERBOSE: [2024-07-29T01:48:42.647+02:00] [New-4meConnection] Parameter: PersonalAccessToken | Value: ***
VERBOSE: [2024-07-29T01:48:42.647+02:00] [New-4meConnection] Parameter: Verbose | Value: True
VERBOSE: [2024-07-29T01:48:42.647+02:00] [New-4meConnection] End
```
```powershell
$meQuery = New-4meMeQuery -Properties ID,Name,PrimaryEmail -Verbose
```
```
VERBOSE: [2024-07-29T01:50:38.488+02:00] [New-4meMeQuery] Start
VERBOSE: [2024-07-29T01:50:38.488+02:00] [New-4meMeQuery] Parameter: Properties | Value: [ID, Name, PrimaryEmail]
VERBOSE: [2024-07-29T01:50:38.488+02:00] [New-4meMeQuery] Parameter: Verbose | Value: True
VERBOSE: [2024-07-29T01:50:38.488+02:00] [New-4meMeQuery] End
```
```powershell
$me = Invoke-4meMeQuery -Query $meQuery -Verbose
```
```
VERBOSE: [2024-07-29T01:51:04.027+02:00] [Invoke-4meMeQuery] Start
VERBOSE: [2024-07-29T01:51:04.027+02:00] [Invoke-4meMeQuery] Parameter: Query | Value: Sdk4me.GraphQL.MeQuery
VERBOSE: [2024-07-29T01:51:04.027+02:00] [Invoke-4meMeQuery] Parameter: Verbose | Value: True
VERBOSE: [2024-07-29T01:51:04.029+02:00] [Invoke-4meMeQuery] {"id":"6851ed51-d841-4c15-a743-0bf7fe198198","method":"POST","uri":"https://graphql.4me.qa/","content":"{\"query\":\"query{me{name primaryEmail id}}\"}","account_id":"account-id"}
VERBOSE: [2024-07-29T01:51:04.091+02:00] [Invoke-4meMeQuery] {"id":"6851ed51-d841-4c15-a743-0bf7fe198198","response_time_in_ms":60}
VERBOSE: [2024-07-29T01:51:04.132+02:00] [Invoke-4meMeQuery] End
```

# Build Instructions
## Prerequisites

1. Install Git 
   - **Windows**: Download and install Git from the [Git website](https://git-scm.com/download/win).
   - **macOS**: Git can be installed via Xcode Command Line Tools, Homebrew or by downloading from the [Git website](https://git-scm.com/download/mac).
   - **Linux**: Install Git using your distribution's package manager.
   
2. Install .NET SDK
   - **Windows**: Download and install the .NET SDK from the [.NET website](https://dotnet.microsoft.com/en-us/download).
   - **macOS**: Download and install the .NET SDK from the [.NET website](https://dotnet.microsoft.com/en-us/download).
   - **Linux**: Install Git using your distribution's package manager.

These prerequisites ensure that your environment is ready for cloning and building the solution across different operating systems.

## 1. Clone the Repository
To get started, clone the repository by opening your terminal or command prompt and running the following command:
```
git clone https://github.com/code4me/4me-graphql-powershell.git
```

## 2. Build the Solution
After cloning the repository, you can build the solution using the `dotnet publish` command.
The project file is located in the `Scr/Sdk4me.GraphQL.PowerShell` directory within the repository.
Navigate to the cloned repository folder and run the following command to build the solution, replacing `"output path"` with the desired output directory:
```
dotnet publish "Sdk4me.GraphQL.PowerShell.csproj" -c Release -f "netstandard2.0" -o "output path"
```
