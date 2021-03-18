Array.prototype.indexOf = function (val) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] == val) return i;
    }
    return -1;
};


Array.prototype.remove = function (val) {
    var index = this.indexOf(val);
    if (index > -1) {
        this.splice(index, 1);
    }
};

// 对Date的扩展，将 Date 转化为指定格式的String   
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，   
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)   
// 例子：   
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423   
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18   
Date.prototype.Format = function (fmt) { //author: meizz   
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}



function formatTime(t1, format) {
    if (t1 != null && t1.indexOf("Date") != -1) {
        var s = "{Date:" + t1 + "}";
        obj = eval('(' + s.replace(/\/Date\((\d+)\)\//gi, "new Date($1)") + ')');
        t1 = obj.Date;
        var o = {
            "M+": t1.getMonth() + 1, //month
            "d+": t1.getDate(),    //day
            "h+": t1.getHours(),   //hour
            "m+": t1.getMinutes(), //minute
            "s+": t1.getSeconds(), //second
            "q+": Math.floor((t1.getMonth() + 3) / 3),  //quarter
            "S": t1.getMilliseconds() //millisecond
        }
        if (/(y+)/.test(format)) format = format.replace(RegExp.$1, (t1.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(format))
                format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        return format;
    }
    else if (t1 != null && t1.length > 0) {
        return (new Date(t1)).Format(format);
    }
    else {
        return "-";
    }
}

function layOpen(setting) {
    layui.use(['table', 'layer'], function () {
        var $ = layui.$
            , table = layui.table
            , layer = layui.layer;

        var options = {
            type: 2
            , title: '添加仓库'
            , content: '@Url.Action("Create")'
            , maxmin: true
            , area: ['840px', '450px']
            , btn: ['确定', '取消']
            , yes: function (index, layero) {
                var iframeWindow = window['layui-layer-iframe' + index]
                    , submitID = 'component-form-demo1'
                    , submit = layero.find('iframe').contents().find('[lay-filter=' + submitID + ']');

                //监听提交
                iframeWindow.layui.form.on('submit(' + submitID + ')', function (data) {

                    //console.log(data.field);
                    var field = data.field; //获取提交的字段
                    delete field.Address;
                    delete field.StorageTypeID;
                    delete field.StorageStatus;
                    delete field.Area;
                    delete field.City;
                    delete field.Province;
                    delete field.StorageCode;
                    delete field.StorageID;
                    delete field.StorageLocation;

                    $.ajax({
                        url: setting.content,
                        type: "post",
                        dataType: "json",
                        data: field,
                        success: function (d) {
                            if (d.code == 0) {
                                layer.msg(setting.msg, {
                                    icon: 1,
                                    time: 2000 //2秒关闭（如果不配置，默认是3秒）
                                }, function () {
                                    table.reload('demo'); //数据刷新
                                        //setting.obj.update({
                                        //    StorageName: field.StorageName,
                                        //    Province: field.Province,
                                        //    StorageCode: field.StorageCode
                                        //});
                                    layer.close(index); //关闭弹层
                                });
                            }
                        }
                    })
                });

                //触发提交
                submit.trigger('click');
            }
        };

        $.extend(options, setting);


        layer.open(options);
    });
}