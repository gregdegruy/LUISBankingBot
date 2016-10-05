﻿using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUISBankingBot.Dialogs
{
    public class LuisBankingDialog
    {
        // if want to test using http call
        // https://api.projectoxford.ai/luis/v1/application?id=6841d389-70d6-45ec-96a9-a2893d1c778e&subscription-key=5d7817feda724399aaf69441f3fb18eb&q={PUT_QUERY_TEXT_HERE}
        [LuisModel("6841d389-70d6-45ec-96a9-a2893d1c778e", "5d7817feda724399aaf69441f3fb18eb")]
        [Serializable]
        public class BankingDialog : LuisDialog<object>
        {
            [LuisIntent("Deposit")]
            public async Task DepositHandler(IDialogContext context, LuisResult result)
            {
                await context.PostAsync("Luis intent recognized as Deposit");
                context.Wait(MessageReceived);
            }

            [LuisIntent("ShowBalance")]
            public async Task ShowBalanceHandler(IDialogContext context, LuisResult result)
            {
                await context.PostAsync("Luis intent recognized as ShowBalance");
                context.Wait(MessageReceived);
            }

            [LuisIntent("Withdraw")]
            public async Task WithdrawHandler(IDialogContext context, LuisResult result)
            {
                await context.PostAsync("Luis intent recognized as Withdraw");
                context.Wait(MessageReceived);
            }

            [LuisIntent("None")]
            public async Task NoneHandler(IDialogContext context, LuisResult result)
            {
                string worriedFace = "\U0001F61F";
                await context.PostAsync("I'm sorry, I don't understand " + worriedFace);
                context.Wait(MessageReceived);
            }
        }
    }
}
