using web1c_backend.Constants;
using web1c_backend.Models.Entities;
using web1c_backend.Models.Http.Params;
using web1c_backend.Models.Contexts;
using web1c_backend.Controllers;
using Moq;
using web1c_backend.Tests.Moks;
using MockQueryable.Moq;

namespace web1c_backend.Tests
{
    public class HistoryTest
    {
        private readonly HistoryController controller;

        public HistoryTest()
        {
            var mockHistoryData = HistoryMock.GetHistory().BuildMock().BuildMockDbSet();
            var mockUserData = HistoryMock.GetUserId().BuildMock().BuildMockDbSet();
            var mockDebtorCardsData = HistoryMock.GetDebtorCards().BuildMock().BuildMockDbSet();

            var mockDbContext = new Mock<Web1cDBContext>();
            mockDbContext.Setup(context => context.History).Returns(mockHistoryData.Object);
            mockDbContext.Setup(context => context.Users).Returns(mockUserData.Object);
            mockDbContext.Setup(context => context.DebtorCards).Returns(mockDebtorCardsData.Object);

            controller = new HistoryController(mockDbContext.Object);
        }

        //Проверяем факт того, что получаемая коллекция - список записей вида En_history
        [Fact]
        public async void ResultIsHistoryList()
        {
            var result = await controller.GetHistory();
            Assert.True(result is List<En_history>);
        }

        //Проверяем факт того, что при получении истории по идентификатору юзера
        //возвращаются записи с заданным идентификатором юзера
        [Fact]
        public async void HistoryIsForGivenUser()
        {
            var userId = (await controller.GetUser()).En_user_id;
            var result = await controller.GetUserHistory(userId);

            Assert.Equal(result.Length, result.Where(resultItem => resultItem.user_id == userId).Count());
        }

        //Проверяем факт того, что при получении информации о записях в истории по внешним ключам и типу сущности
        //возвращаются записи соответствующего типа данных
        [Fact]
        public async void HistoryItemsHaveCorrectTypes()
        {
            var userId = (await controller.GetUser()).En_user_id;
            var rawHistory = await controller.GetUserHistory(userId);

            var historyParams = new GetParams()
            {
                Type = 2
            };
            var result = await controller.MapHistoryToEntities(rawHistory, historyParams);

            Assert.True(result.All(resultItem => resultItem is En_debtor_card));
        }

        //Проверяем факт того, что при получении информации о записях в истории по внешним ключам и типу сущности
        //возвращаются записи с соответствующими внешним ключам идентификаторами
        [Fact]
        public async void HistoryItemsHaveCorrectIds()
        {
            var userId = (await controller.GetUser()).En_user_id;
            var rawHistory = await controller.GetUserHistory(userId);

            var historyEntityIds = rawHistory
                .Select(historyItem => historyItem.entity_id)
                .ToList();

            var historyParams = new GetParams()
            {
                Type = 2
            };
            var result = await controller.MapHistoryToEntities(rawHistory, historyParams);
            var resultEntityIds = result
                .Select(resultItem =>
                {
                    var itemId = 0L;

                    if (resultItem is En_debtor_card debtorCard)
                    {
                        itemId = debtorCard.debtor_card_id;
                    }

                    return itemId;
                })
                .ToList();

            Assert.True(resultEntityIds.SequenceEqual(historyEntityIds));
        }

        //Проверяем факт успешного добавления записи в историю
        [Fact]
        public async void HistoryInsertionIsSuccessfull()
        {
            var debtorCard = new En_debtor_card()
            {
                debtor_card_id = 10
            };
            var session = new En_session()
            {
                En_session_id = 30,
                En_user_id = 4
            };
            var historyTarget = new En_history()
            {
                entity_id = debtorCard.debtor_card_id,
                entity_type_id = (byte) EntityTypes.DEBTOR_CARD,
                user_id = session.En_user_id
            };

            var insertedItem = await controller.UpdateHistory(debtorCard, session.En_user_id);

            Assert.True(insertedItem.entity_id == historyTarget.entity_id &&
                insertedItem.entity_type_id == historyTarget.entity_type_id &&
                insertedItem.user_id == historyTarget.user_id);
        }
    }
}
