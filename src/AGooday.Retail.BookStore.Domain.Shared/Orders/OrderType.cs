using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGooday.Retail.BookStore.Orders
{
    /// <summary>
    /// 订单类型
    /// https://www.mql5.com/zh/docs/constants/tradingconstants/orderproperties#enum_order_type
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 市场购买订单
        /// </summary>
        BUY,
        /// <summary>
        /// 市场卖出订单
        /// </summary>
        SELL,
        /// <summary>
        /// 限制买入待办订单
        /// </summary>
        BUY_LIMIT,
        /// <summary>
        /// 限制卖出待办订单
        /// </summary>
        SELL_LIMIT,
        /// <summary>
        /// 停止买入待办订单
        /// </summary>
        BUY_STOP,
        /// <summary>
        /// 停止卖出待办订单
        /// </summary>
        SELL_STOP,
        /// <summary>
        /// 在到达订单价格之上，是限制买入订单安置在停止限制价格中
        /// </summary>
        BUY_STOP_LIMIT,
        /// <summary>
        /// 在到达订单价格之上，是限制卖出订单安置在停止限制价格中
        /// </summary>
        SELL_STOP_LIMIT,
        /// <summary>
        /// 通过反向持仓平仓的订单
        /// </summary>
        CLOSE_BY,
    }
}
