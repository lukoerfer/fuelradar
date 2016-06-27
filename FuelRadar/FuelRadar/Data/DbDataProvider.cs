﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Xamarin.Forms;

using FuelRadar.Model;

namespace FuelRadar.Data
{
    public class DbDataProvider : IDataProvider
    {
        private static DbDataProvider singleton = null;
        public static DbDataProvider Instance
        {
            get
            {
                if (DbDataProvider.singleton == null) DbDataProvider.singleton = new DbDataProvider();
                return DbDataProvider.singleton;
            }
        }

        private Object DbLock;
        private SQLiteConnection DbConnection;

        private DbDataProvider()
        {
            this.DbLock = new Object();
            this.DbConnection = DependencyService.Get<ISqliteProvider>().GetConnection();
            this.DbConnection.CreateTable<FavouriteStationData>();
            this.DbConnection.CreateTable<HistoricalPriceData>();
        }

        public List<Station> GetFavouriteStations()
        {
            //List<FavouriteStationData> queryResult;
            //lock (this.DbLock)
            //{
            //    queryResult = this.DbConnection.Table<FavouriteStationData>().ToList();
            //}
            //return queryResult.Select(favData => favData.ToStation()).ToList();
            return (new Station[] { new Station("23e1143f-c734-4968-aadf-6a6954ba4db7", "Demo Shell", "Shell", 0, 0),
                new Station("35a865a4-ea2c-4f98-b0e1-dd395e6f2b53", "DEMO Aral Tankstelle", "Aral", 0, 0) }).ToList();
        }

        public int GetFavouriteStationCount()
        {
            //lock (this.DbLock)
            //{
            //    return this.DbConnection.Table<FavouriteStationData>().Count();
            //}
            return 2;
        }

        public void AddFavouriteStation(Station gasStation)
        {
            lock (this.DbLock)
            {
                int count = this.DbConnection.Table<FavouriteStationData>().Count();
                if (count == 10)
                {
                    // TODO: Delete a favorite
                }
                this.DbConnection.Insert(new FavouriteStationData(gasStation));
            }
        }

        public void RemoveFavouriteStation(string gasStationId)
        {
            lock (this.DbLock)
            {
                this.DbConnection.Execute("");
            }
        }

        public bool IsFavorite(string gasStationId)
        {
            return false;
        }

        public List<Price> GetAllHistoricalPrices()
        {
            lock (this.DbLock)
            {
                return null;
            }
        }

        public void AddPriceToHistory(Price price)
        {
            lock (this.DbLock)
            {
                
            }
        }

    }
}
