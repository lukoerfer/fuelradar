﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FuelRadar.Model;

namespace FuelRadar.Data
{
    public interface IDataProvider
    {
        // Gas stations

        List<Station> GetFavouriteStations();

        void AddFavouriteStation(Station gasStation);

        void RemoveFavouriteStation(Station gasStation);

        // Prices

        List<Price> GetAllHistoricalPrices();

        void AddPriceToHistory(Price price);
    }
}
