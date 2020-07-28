using System;
using System.Collections.Concurrent;
using Code.Common.Logger;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Common.Storages
{
    public class WarshipsStorage
    {
        public static WarshipsStorage Instance { get; } = new WarshipsStorage();
        private readonly ILog log = LogManager.CreateLogger(typeof(WarshipsStorage));
        private readonly ConcurrentDictionary<WarshipTypeEnum, WarshipDto> warships = 
            new ConcurrentDictionary<WarshipTypeEnum, WarshipDto>();
        
        public WarshipDto GetWarshipModel(WarshipTypeEnum warshipTypeEnum)
        {
            if (warships.TryGetValue(warshipTypeEnum, out var warshipDto))
            {
                return warshipDto;
            }

            throw new Exception("Такого корабля нет. "+warshipTypeEnum);
        }

        public void AddOrUpdate(WarshipTypeEnum warshipTypeEnum, WarshipDto warshipDto)
        {
            warships.AddOrUpdate(warshipTypeEnum, warshipDto, 
                (key, oldValue) => warshipDto);
        }
    }
}