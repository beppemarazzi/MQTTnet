// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace MQTTnet.Client
{
    public sealed class MqttClientTlsOptions
    {
        public Func<MqttClientCertificateValidationEventArgs, bool> CertificateValidationHandler { get; set; }

        public bool UseTls { get; set; }

        public bool IgnoreCertificateRevocationErrors { get; set; }

        public bool IgnoreCertificateChainErrors { get; set; }

        public bool AllowUntrustedCertificates { get; set; }

        public X509RevocationMode RevocationMode { get; set; } = X509RevocationMode.Online;

#if WINDOWS_UWP
        public List<byte[]> Certificates { get; set; }
#else
        public List<X509Certificate> Certificates { get; set; }
#endif

#if NETCOREAPP3_1 || NET5_0_OR_GREATER
        public List<System.Net.Security.SslApplicationProtocol> ApplicationProtocols { get; set; }
        
        public System.Net.Security.CipherSuitesPolicy CipherSuitesPolicy { get; set; }
#endif

#if NET48 || NETCOREAPP3_1 || NET5 || NET6
        public SslProtocols SslProtocol { get; set; } = SslProtocols.Tls12 | SslProtocols.Tls13;
#else
        public SslProtocols SslProtocol { get; set; } = SslProtocols.Tls12 | (SslProtocols)0x00003000 /*Tls13*/;
#endif
    }
}