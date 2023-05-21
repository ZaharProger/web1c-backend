using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web1c_backend.Constants;
using web1c_backend.Models.Contexts;
using web1c_backend.Models.Entities;

namespace web1c_backend.Controllers
{
    public class Web1cController : ControllerBase
    {
        protected Web1cDBContext context;

        public Web1cController(Web1cDBContext context)
        {
            this.context = context;
        }

        protected long? CheckSession(string cookieKey)
        {
            long? sessionId;
            if (HttpContext.Request.Cookies[cookieKey] != null)
            {
                try
                {
                    sessionId = long.Parse(HttpContext.Request.Cookies[cookieKey]);
                }
                catch (FormatException)
                {
                    sessionId = null;
                }
            }
            else
            {
                sessionId = null;
            }

            return sessionId;
        }

        [NonAction]
        public async Task<En_history> UpdateHistory(EntityWithRoute entity, long? userId)
        {
            EntityTypes entityType = EntityTypes.DEBTOR_CARD;
            long entityKey = 0L;

            if (entity is En_debtor_card debtorCard)
            {
                entityType = EntityTypes.DEBTOR_CARD;
                entityKey = debtorCard.debtor_card_id;
            }

            var entityTypeNum = (byte)entityType;
            var isFound = await context.History
                .Where(history => history.entity_id == entityKey &&
                    history.entity_type_id == entityTypeNum && history.user_id == userId)
                .AnyAsync();

            var newHistory = new En_history();
            if (!isFound)
            {
                newHistory.entity_type_id = entityTypeNum;
                newHistory.entity_id = entityKey;
                newHistory.user_id = userId;

                await context.History
                    .AddAsync(newHistory);

                await context.SaveChangesAsync();
            }

            return newHistory;
        }
    }
}
