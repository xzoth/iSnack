/// <reference path="resources/script/sencha-touch-all.js" />

Ext.application({
    name: 'senchaTouchTest',
    viewport: { autoMaximize: true},
    useLoadMask: true,
    launch: function () {// 应用启动时执行该方法 

//        Ext.Viewport.setMasked({ xtype: 'loadmask', message: '应用程序正在启动......', indicator: true, showAnimation: 'slideIn'});
     
        Ext.create('Ext.Panel', {
            layout: 'hbox',
            fullscreen: true,
            items: [
                        {
                            xtype: 'panel',
                            layout: 'fix',
                            flex: 1,
                            style: 'background-color: #5E99CC;'
                        },
                        {
                            xtype: 'formpanel',
                            id: 'myForm',
                            flex: 2,
                            title: '表单标题',
                            style: 'background-color: #759E60;',
                            items: [
                                    {
                                        xtype: 'fieldset',
                                        title: '内框标题',
                                        items: [
                                                {
                                                    xtype: 'textareafield',
                                                    label: '值名称',
                                                    placeHolder: '输入任意字符串',
                                                    autoComplete: true,
                                                    autoCorrect: true,
                                                    id: 'word',
                                                    maxRows: 5
                                                }
                                                ]
                                    },
                                    {
                                        xtype: 'button',
                                        text: 'Get',
                                        ui: 'confirm-round',
                                        handler: function () {
                                            Ext.Ajax.request({
                                                    url: 'http://localhost:2030/api/HelloWord/',
                                                    method: 'GET',
                                                    success: function(response, opts){
                                                        Ext.getCmp('word').setValue(response.responseText);
                                                    }
                                                });
                                        }
                                    },
                                    {
                                        xtype: 'button',
                                        text: 'Get By Word',
                                        ui: 'decline-round',
                                        handler: function () {
                                            var strWord = Ext.htmlEncode(Ext.getCmp('word').getValue());

                                            Ext.Ajax.request({
                                                    url: 'http://localhost:2030/api/Product/4',
                                                    withCredentials: false,
                                                    useDefaultXhrHeader: false,
                                                    disableCaching: false,
                                                    method: 'put',
                                                    timeout: 30000,
                                                    headers: { "Content-Type": "application/json" },
//                                                    form: 'myForm',
                                                    params: Ext.JSON.encode({ ID: 4, Name: '暴雪游戏鼠标垫', Category: '电脑配件', Price: 120}),
                                                    success: function(response, opts){
                                                        Ext.getCmp('word').setValue(response.responseText);
                                                    },
                                                    failure: function(response, opts){
                                                        var text = response.responseText;
                                                        var txtId = Ext.getCmp('word');
                                                        
                                                        if (response.timedout){
                                                            Ext.Msg.alert('错误', '请求超时');
                                                        }
                                                        else if (response.aborted){
                                                            Ext.Msg.alert('提示', '请求已取消');
                                                        }
                                                        else{
                                                            Ext.Msg.alert('错误', response.responseText);
                                                            txtId.setValue(text);
                                                        }
                                                    },
                                                    callback: function(opts, isSucc, response){
                                                        //todo callback
                                                    }
                                                });
                                        }
                                    },
                                    {
                                        xtype: 'button',
                                        text: '普通按钮',
                                    },
                                    {
                                        xtype: 'button',
                                        text: '小按钮',
                                        ui: 'small'
                                    }
                                    ]
                        }
                    ]
        });

//        Ext.Viewport.setMasked(false);
    }
});