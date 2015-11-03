﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Api.Net.Domain.Campaigns;
using MailChimp.Api.Net.Enum;
using Newtonsoft.Json;

namespace MailChimp.Api.Net.Services.Campaigns
{
    // ==================================================================================================================================================
    // AUTHOR      : Shahriar Hossain
    // PURPOSE     : Campaigns are how you send emails to your MailChimp list. Use the Campaigns API calls to manage campaigns in your MailChimp account.
    // ===================================================================================================================================================
    internal class MCCampaignsOverview
    {
        /// <summary>
        /// Get all campaigns
        /// </summary>
        internal async Task<RootCampaign> GetCampaignsAsync()
        {
            string endpoint = Authenticate.EndPoint(TargetTypes.campaigns, SubTargetType.not_applicable, SubTargetType.not_applicable);

            string content;
            using (var client = new HttpClient())
            {
                try
                {
                    Authenticate.ClientAuthentication(client);

                    content = await client.GetStringAsync(endpoint).ConfigureAwait(false);
                }
                catch (Exception ex)
                {    
                    throw ex; 
                } 
            }

            return JsonConvert.DeserializeObject<RootCampaign>(content);
        }

        /// <summary>
        /// Get information about a specific campaign
        /// <param name="campaignId">Unique id for the campaign</param>
        /// </summary>
        internal async Task<Campaign> GetCampaignByIdAsync(string campaignId)
        {
            string endpoint = Authenticate.EndPoint(TargetTypes.campaigns, SubTargetType.not_applicable, SubTargetType.not_applicable, campaignId);

            string content;
            using (var client = new HttpClient())
            {
                try
                {
                    Authenticate.ClientAuthentication(client);

                    content = await client.GetStringAsync(endpoint).ConfigureAwait(false);
                }
                catch (Exception ex)
                { 
                    throw ex;
                }
            }

            return JsonConvert.DeserializeObject<Campaign>(content);
        }

        /// <summary>
        /// Delete a campaign
        /// <param name="campaignId">Unique id for the campaign</param>
        /// </summary>
        internal async Task<HttpResponseMessage> DeleteCampaignByIdAsync(string campaignId)
        {
            string endpoint = Authenticate.EndPoint(TargetTypes.campaigns, SubTargetType.not_applicable, SubTargetType.not_applicable, campaignId);

            HttpResponseMessage result;
            using (var client = new HttpClient())
            {
                try
                {
                    Authenticate.ClientAuthentication(client);

                    result = await client.DeleteAsync(endpoint).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        /// <summary>
        /// Cancel a campaign
        /// <param name="campaignId">Unique id for the campaign</param>
        /// </summary>
        internal async Task<HttpResponseMessage> CancelCampaignByIdAsync(string campaignId)
        {
            string endpoint = Authenticate.EndPoint(TargetTypes.campaigns, SubTargetType.action3, SubTargetType.not_applicable, campaignId);

            HttpResponseMessage message = new HttpResponseMessage();
            StringContent tempMsg= new StringContent("NOT IMPLEMENTED YET");
            message.Content = tempMsg;
            return message;
           
        }
    }
}
