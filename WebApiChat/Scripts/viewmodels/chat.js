
var ChatPage = function (currentUser) {
    var self = this;

    self.chats = ko.observableArray();

    self.newChatUser = ko.observable();

    self.openChat = function () {
        $.ajax({
            url: '/api/users/find/' + self.newChatUser(),
            success: function (data) {
                self.chats.push(new Chat(currentUser, data));
                self.newChatUser('');
            }
        });
    };
};

var Chat = function (currentUser, chatPartner) {
    var self = this;

    self.messages = ko.observableArray([]);

    self.currentBody = ko.observable('');

    self.sendMessage = function () {
        self.currentBody('');
        $.ajax({
            type: 'post',
            url: '/api/messages',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                to: chatPartner.id,
                from: currentUser.id,
                body: self.currentBody()
            })
        });
    };

    function listenForNewMessages() {
        setInterval(function () {
            $.ajax({
                url: '/api/messages?to=' + currentUser.id + '&from=' + chatPartner.id,
                success: function (data) {
                    self.messages(data);
                }
            });
        }, 1000);
    }
    listenForNewMessages();
}
