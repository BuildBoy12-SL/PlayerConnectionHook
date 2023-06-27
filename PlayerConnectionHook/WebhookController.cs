// -----------------------------------------------------------------------
// <copyright file="WebhookController.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace PlayerConnectionHook
{
    using System;
    using DiscordHook;
    using DiscordHook.Embeds;
    using DiscordHook.Embeds.Builders.AuthorBuilder;
    using DiscordHook.Embeds.Builders.EmbedBuilder;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Interfaces;
    using Exiled.Events.EventArgs.Player;

    /// <summary>
    /// Manages interactions with the webhook.
    /// </summary>
    public class WebhookController
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookController"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public WebhookController(Plugin plugin)
        {
            this.plugin = plugin;
        }

        /// <summary>
        /// Sends a message via the webhook.
        /// </summary>
        /// <param name="player">The player that is joining or leaving.</param>
        /// <param name="ev">The joining or leaving event arguments.</param>
        public void SendMessage(Player player, IExiledEvent ev)
        {
            if (player is null)
                return;

            bool isJoining = ev is VerifiedEventArgs;
            Webhook webhook = new();
            webhook.WithEmbed(BuildEmbed(player, isJoining)).Send(plugin.Config.WebhookUrl);
        }

        private Embed BuildEmbed(Player player, bool isJoining)
        {
            Author author = AuthorBuilder.Create()
                .WithName(isJoining ? plugin.Translation.PlayerJoinedTitle : plugin.Translation.PlayerLeftTitle)
                .WithIconUrl(plugin.Translation.TitleImage)
                .WithUrl(null)
                .Build();

            Embed embed = EmbedBuilder.Create()
                .WithAuthor(author)
                .WithTitle(null)
                .WithUrl(null)
                .WithDescription(Format(player, isJoining))
                .WithColor(Color.DarkBlue)
                .WithFields(null)
                .WithTimestamp(DateTimeOffset.Now)
                .WithFooter(plugin.Translation.EmbedFooter)
                .Build();

            return embed;
        }

        private string Format(Player player, bool isJoining)
        {
            return string.Format(
                isJoining ? plugin.Translation.PlayerJoined : plugin.Translation.PlayerLeft,
                player.Nickname,
                Server.Name,
                Server.Port,
                isJoining ? Server.PlayerCount : Server.PlayerCount - 1,
                Server.MaxPlayerCount);
        }
    }
}