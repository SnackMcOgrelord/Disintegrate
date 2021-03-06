﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disintegrate.Configuration.Configurators
{
    public class Dota2Configurator : Configurator
    {
        const int SteamId = 570;
        const string FileName = "gamestate_integration_disintegrate.cfg";
        const string Config = @"""Disintegrate Integration Configuration""
{
    ""uri""           ""http://localhost:4000/""
    ""timeout""       ""5.0""
    ""buffer""        ""0.1""
    ""throttle""      ""0.1""
    ""heartbeat""     ""30.0""
    ""data""
    {
        ""provider""      ""1""
        ""map""           ""1""
        ""player""        ""1""
        ""hero""          ""1""
        ""abilities""     ""1""
        ""items""         ""1""
    }
}";

        public override List<string> Configure()
        {
            var gsiDir = $"{SteamLocator.FindGame(SteamId)}\\game\\dota\\cfg\\gamestate_integration\\";
            Directory.CreateDirectory(gsiDir);

            File.WriteAllText($"{gsiDir}\\{FileName}", Config);

            return new List<string> { $"{gsiDir}\\{FileName}" };
        }

        public override bool IsConfigured() =>
            File.Exists($"{SteamLocator.FindGame(SteamId)}\\game\\dota\\cfg\\gamestate_integration\\{FileName}");
    }
}
