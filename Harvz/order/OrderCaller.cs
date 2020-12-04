namespace Harvz.order
{
    /// <summary>
    /// Basic order caller.
    /// </summary>
    internal struct OrderCaller
    {
        /// <summary>
        /// Call an order followed by the message content.
        /// </summary>
        /// <param name="s_order"></param>
        public static void call_order_s(string s_order)
        {
            var args = s_order.Split(' ');
            // TODO: Setup basic orders.
            switch (s_order)
            {
                case ">hv ping": break;
            }
        }
    }
}