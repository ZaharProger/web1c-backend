using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web1c_backend.Constants;
using web1c_backend.Models;
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

        protected async Task UpdateHistory(EntityWithRoute entity, long sessionId)
        {
            EntityTypes entityType = EntityTypes.DEBTOR_CARD;
            long entityKey = 0L;

            if (entity is En_debtor_card debtorCard)
            {
                entityType = EntityTypes.DEBTOR_CARD;
                entityKey = debtorCard.debtor_card_id;
            }

            var entityTypeNum = (byte)entityType;
            var foundSession = await context.Sessions.FindAsync(sessionId);
            var isFound = await context.History
                .Where(history => history.entity_id == entityKey &&
                    history.entity_type_id == entityTypeNum && history.user_id == foundSession.En_user_id)
                .AnyAsync();

            if (!isFound)
            {
                await context.History
                    .AddAsync(new En_history()
                    {
                        entity_id = entityKey,
                        entity_type_id = entityTypeNum,
                        user_id = foundSession?.En_user_id
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}
