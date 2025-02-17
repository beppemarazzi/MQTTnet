// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using MQTTnet.Packets;
using MQTTnet.Protocol;

namespace MQTTnet.Formatter;

public static class MqttPubRelPacketFactory
{
    public static MqttPubRelPacket Create(MqttPubRecPacket pubRecPacket, MqttApplicationMessageReceivedReasonCode reasonCode)
    {
        ArgumentNullException.ThrowIfNull(pubRecPacket);

        return new MqttPubRelPacket
        {
            PacketIdentifier = pubRecPacket.PacketIdentifier,
            ReasonCode = (MqttPubRelReasonCode)(int)reasonCode
        };
    }
}