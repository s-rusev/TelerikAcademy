﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BetMania.Database;
using BetMania.Services.Models;
using BetMania.Services.Helpers;
using System.Web.Http.ValueProviders;
using BetMania.Services.CustomHeaderValueProviders;

namespace BetMania.Services.Controllers
{
    public class BetsController : BaseApiController
    {
        private BetManiaContext db;

        public BetsController(BetManiaContext db)
        {
            if (db == null)
            {
                throw new ArgumentNullException("db");
            }
            this.db = db;
        }

        // GET api/bets/{id}
        public HttpResponseMessage GetBets(int id,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            HttpResponseMessage response = this.ProcessOperation(() =>
            {
                User user = this.db.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();
                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "You are not logged in.");
                }

                IQueryable<Bet> bets;
                if (user.IsAdmin)
                {
                    bets = this.db.Bets.Where(b => b.MatchId == id);
                }
                else
                {
                    bets = this.db.Bets.Where(b => b.MatchId == id && b.UserId == user.Id);
                }

                return Request.CreateResponse(HttpStatusCode.OK, this.ConvertToBetDTOs(bets));
            });

            return response;
        }

        // GET api/bets/bettypes
        [ActionName("bettypes")]
        public HttpResponseMessage GetBetTypes()
        {
            HttpResponseMessage response = this.ProcessOperation(() =>
            {
                var betTypes = this.ConvertToBetTypeDTOs(this.db.BetTypes).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, betTypes);
            });

            return response;
        }

        private IQueryable<BetAdditionDTO> ConvertToBetDTOs(IQueryable<Bet> bets)
        {
            return bets.Select(b => new BetAdditionDTO()
            {
                Amount = b.Amount,
                BetType = b.BetType.Name
            });
        }

        private IQueryable<BetTypeDTO> ConvertToBetTypeDTOs(IQueryable<BetType> bets)
        {
            return bets.Select(b => new BetTypeDTO()
            {
                Id = b.Id,
                Name = b.Name
            });
        }
    }
}
