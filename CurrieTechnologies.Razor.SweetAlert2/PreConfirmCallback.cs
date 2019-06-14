﻿namespace CurrieTechnologies.Razor.SweetAlert2
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;

    /// <summary>
    /// A bound event handler delagate.
    /// </summary>
    public class PreConfirmCallback
    {
        private readonly Func<string, Task<string>> asyncCallback;
        private readonly Func<string, string> syncCallback;
        private readonly Func<IEnumerable<string>, Task<IEnumerable<string>>> asyncQueueCallback;
        private readonly Func<IEnumerable<string>, IEnumerable<string>> syncQueueCallback;
        private readonly EventCallback eventCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreConfirmCallback"/> class.
        /// Creates a <see cref="PreConfirmCallback"/> for the provided <paramref name="receiver"/> and <paramref name="callback"/>.
        /// <para>Use in Fire requests.</para>
        /// </summary>
        /// <param name="receiver">The event receiver. Pass in `this` from the calling component.</param>
        /// <param name="callback">The event callback.</param>
        /// <exception cref="ArgumentException">Thrown if used in Queue request.</exception>
        public PreConfirmCallback(object receiver, Func<string, Task<string>> callback)
        {
            this.asyncCallback = callback;
            this.eventCallback = EventCallback.Factory.Create(receiver, () => { });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreConfirmCallback"/> class.
        /// Creates a <see cref="PreConfirmCallback"/> for the provided <paramref name="receiver"/> and <paramref name="callback"/>.
        /// <para>Use in Fire requests.</para>
        /// </summary>
        /// <param name="receiver">The event receiver. Pass in `this` from the calling component.</param>
        /// <param name="callback">The event callback.</param>
        /// <exception cref="ArgumentException">Thrown if used in Queue request.</exception>
        public PreConfirmCallback(object receiver, Func<string, string> callback)
        {
            this.syncCallback = callback;
            this.eventCallback = EventCallback.Factory.Create(receiver, () => { });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreConfirmCallback"/> class.
        /// Creates a <see cref="PreConfirmCallback"/> for the provided <paramref name="receiver"/> and <paramref name="callback"/>.
        /// <para>Use in Queue requests.</para>
        /// </summary>
        /// <param name="receiver">The event receiver. Pass in `this` from the calling component.</param>
        /// <param name="callback">The event callback.</param>
        /// <exception cref="ArgumentException">Thrown if used in Fire request.</exception>
        public PreConfirmCallback(object receiver, Func<IEnumerable<string>, Task<IEnumerable<string>>> callback)
        {
            this.asyncQueueCallback = callback;
            this.eventCallback = EventCallback.Factory.Create(receiver, () => { });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreConfirmCallback"/> class.
        /// Creates a <see cref="PreConfirmCallback"/> for the provided <paramref name="receiver"/> and <paramref name="callback"/>.
        /// <para>Use in Queue requests.</para>
        /// </summary>
        /// <param name="receiver">The event receiver. Pass in `this` from the calling component.</param>
        /// <param name="callback">The event callback.</param>
        /// <exception cref="ArgumentException">Thrown if used in Fire request.</exception>
        public PreConfirmCallback(object receiver, Func<IEnumerable<string>, IEnumerable<string>> callback)
        {
            this.syncQueueCallback = callback;
            this.eventCallback = EventCallback.Factory.Create(receiver, () => { });
        }

        /// <summary>
        /// Invokes the delegate associated with this binding and dispatches an event notification to the appropriate component.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <exception cref="ArgumentException">Thrown if used in Queue request.</exception>
        public async Task<string> InvokeAsync(string arg)
        {
            string ret;
            if (this.asyncCallback != null)
            {
                ret = await this.asyncCallback(arg);
            }
            else if (this.syncCallback != null)
            {
                ret = this.syncCallback(arg);
            }
            else
            {
                throw new ArgumentException("use string (not IEnumerable<string>) for Fire requests");
            }

            await this.eventCallback.InvokeAsync(arg);
            return ret;
        }

        /// <summary>
        /// Invokes the delegate associated with this binding and dispatches an event notification to the appropriate component.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <exception cref="ArgumentException">Thrown if used in Fire request.</exception>
        public async Task<IEnumerable<string>> InvokeAsync(IEnumerable<string> arg)
        {
            IEnumerable<string> ret;
            if (this.asyncQueueCallback != null)
            {
                ret = await this.asyncQueueCallback(arg);
            }
            else if (this.syncQueueCallback != null)
            {
                ret = this.syncQueueCallback(arg);
            }
            else
            {
                throw new ArgumentException("use IEnumerable<string> for Queue requests");
            }

            await this.eventCallback.InvokeAsync(arg);
            return ret;
        }
    }
}