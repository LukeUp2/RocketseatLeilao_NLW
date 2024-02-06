using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCase.Leiloes.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        public Auction? Execute()
        {
            var respository = new RocketseatAuctionDbContext();

            var today = new DateTime(2024, 05, 01);

            return respository
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }

}
