using System;
using Unity.Netcode;
using Unity.Collections;

namespace Unity.Game
{

    public struct PlayerData : INetworkSerializable, IEquatable<PlayerData>
    {
        public ulong Id;
        public FixedString64Bytes PlayerName;
        public int TeamIndex;

        public PlayerData(ulong id, string playerName, int teamIndex)
        {
            Id = id;
            PlayerName = new FixedString64Bytes(playerName);
            TeamIndex = teamIndex;
        }

        public bool Equals(PlayerData other)
        {
            return Id == other.Id && 
                   PlayerName.Equals(other.PlayerName) && 
                   TeamIndex == other.TeamIndex;
        }

        public override bool Equals(object obj)
        {
            return obj is PlayerData other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, PlayerName, TeamIndex);
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref Id);
            serializer.SerializeValue(ref PlayerName);
            serializer.SerializeValue(ref TeamIndex);
        }
    }
}
