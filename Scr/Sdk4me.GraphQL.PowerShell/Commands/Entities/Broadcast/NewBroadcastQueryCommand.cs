﻿using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Broadcast query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "BroadcastQuery")]
    [OutputType(typeof(Broadcast))]
    public class NewBroadcastQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the broadcast query, rendering other filters redundant by directly referencing a specific object.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? ID { get; set; }

        /// <summary>
        /// The request specifies a maximum number of items per request. The allowed range for the number of items is between 1 and 100, inclusive..
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int ItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// An array of a broadcast properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public BroadcastField[] Properties { get; set; } = Array.Empty<BroadcastField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DefaultView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DefaultOrderField OrderBy { get; set; }

        /// <summary>
        /// <br>Specifies the sorting order for the order by field.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrderBySortOrder SortOrder { get; set; } = OrderBySortOrder.None;

        /// <summary>
        /// Specify the Account to be returned using an account query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery Account { get; set; } = new();

        /// <summary>
        /// Specify the Customers to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Customers { get; set; } = new();

        /// <summary>
        /// Specify the Email template to be returned using an email template query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EmailTemplateQuery EmailTemplate { get; set; } = new();

        /// <summary>
        /// Specify the Organizations to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Organizations { get; set; } = new();

        /// <summary>
        /// Specify the Remarks attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery RemarksAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Request to be returned using a request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery Request { get; set; } = new();

        /// <summary>
        /// Specify the Service instances to be returned using a service instance query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery ServiceInstances { get; set; } = new();

        /// <summary>
        /// Specify the Sites to be returned using a site query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery Sites { get; set; } = new();

        /// <summary>
        /// Specify the Skill pools to be returned using a skill pool query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolQuery SkillPools { get; set; } = new();

        /// <summary>
        /// Specify the SLAs to be returned using a service level agreement query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementQuery Slas { get; set; } = new();

        /// <summary>
        /// Specify the Teams to be returned using a team query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery Teams { get; set; } = new();

        /// <summary>
        /// Specify the Translations to be returned using a broadcast translation query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public BroadcastTranslationQuery Translations { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the a broadcast query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<BroadcastQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<BroadcastQuery>>();

        /// <summary>
        /// Initializes the processing of the command.
        /// </summary>
        protected override void BeginProcessing()
        {
            this.StartProcessingHeader();
            this.WriteParameters();
        }

        /// <summary>
        /// Constructs and configures the object based on the provided parameters, and outputs it.
        /// </summary>
        protected override void ProcessRecord()
        {
            BroadcastQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

            if (MyInvocation.BoundParameters.ContainsKey("ItemsPerRequest"))
            {
                retval.ItemsPerRequest(ItemsPerRequest);
            }
            if (MyInvocation.BoundParameters.ContainsKey("View"))
            {
                retval.View(View);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OrderBy"))
            {
                retval.OrderBy(OrderBy, SortOrder);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Account"))
            {
                retval.SelectAccount(Account);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Customers"))
            {
                retval.SelectCustomers(Customers);
            }
            if (MyInvocation.BoundParameters.ContainsKey("EmailTemplate"))
            {
                retval.SelectEmailTemplate(EmailTemplate);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Organizations"))
            {
                retval.SelectOrganizations(Organizations);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RemarksAttachments"))
            {
                retval.SelectRemarksAttachments(RemarksAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Request"))
            {
                retval.SelectRequest(Request);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstances"))
            {
                retval.SelectServiceInstances(ServiceInstances);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Sites"))
            {
                retval.SelectSites(Sites);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SkillPools"))
            {
                retval.SelectSkillPools(SkillPools);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Slas"))
            {
                retval.SelectSlas(Slas);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Teams"))
            {
                retval.SelectTeams(Teams);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Translations"))
            {
                retval.SelectTranslations(Translations);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<BroadcastQuery> filter in Filters)
                {
                    if (filter.StringValues != null)
                    {
                        retval.Filter(filter.Property, filter.Operator, filter.StringValues);
                    }
                    else if (filter.DateTimeValues != null)
                    {
                        retval.Filter(filter.Property, filter.Operator, filter.DateTimeValues);
                    }
                    else if (filter.BooleanValue != null)
                    {
                        retval.Filter(filter.Property, filter.Operator, filter.BooleanValue.Value);
                    }
                    else if (filter.Operator.IsNullableOperator())
                    {
                        retval.Filter(filter.Property, filter.Operator);
                    }
                }
            }

            retval.Select(Properties);
            WriteObject(retval);
        }

        /// <summary>
        /// Completes the processing of the command. This method is called once after all records have been processed.
        /// </summary>
        protected override void EndProcessing()
        {
            this.EndProcessingFooter();
        }
    }
}