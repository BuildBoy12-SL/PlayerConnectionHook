// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace PlayerConnectionHook
{
    using System;
    using Exiled.API.Features;

    /// <inheritdoc />
    public class Plugin : Plugin<Config, Translation>
    {
        private EventHandlers eventHandlers;

        /// <summary>
        /// Gets an instance of the <see cref="PlayerConnectionHook.WebhookController"/> class.
        /// </summary>
        public WebhookController WebhookController { get; private set; }

        /// <inheritdoc/>
        public override string Author => "Build";

        /// <inheritdoc/>
        public override string Name => "PlayerConnectionHook";

        /// <inheritdoc/>
        public override string Prefix => "PlayerConnectionHook";

        /// <inheritdoc/>
        public override Version Version { get; } = new(1, 0, 0);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new(7, 0, 5);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Player.Destroying += eventHandlers.OnDestroying;
            Exiled.Events.Handlers.Player.Verified += eventHandlers.OnVerified;

            WebhookController = new WebhookController(this);
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            WebhookController = null;

            Exiled.Events.Handlers.Player.Destroying -= eventHandlers.OnDestroying;
            Exiled.Events.Handlers.Player.Verified -= eventHandlers.OnVerified;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}