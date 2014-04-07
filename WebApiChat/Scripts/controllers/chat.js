app.controller('ChatPage', function ($scope, $http) {

    $scope.chats = [];

    $scope.newChatUser = '';

    $scope.openChat = function () {
        $http({
            method: 'GET',
            url: '/api/users/' + $scope.newChatUser
        }).success(function (data) {
            $scope.chats.push({ currentUser: $scope.currentUser, otherUser: data });
            $scope.newChatUser = '';
        });
    };
});
app.controller('Chat', function ($scope, $http, $interval) {

    $scope.messages = [];

    $scope.currentBody = '';

    $scope.chatPartner = {};

    $scope.sendMessage = function () {
        $http({
            method: 'POST',
            url: '/api/messages/' + $scope.newChatUser,
            data: JSON.stringify({
                to: $scope.chatPartner.id,
                from: $scope.currentUser.id,
                body: $scope.currentBody
            })
        }).success(function (data) {
            $scope.messages.push(data);
            $scope.currentBody = ''
        });
    };

    function refreshData() {
        $http({
            method: 'GET',
            url: '/api/messages?to=' + $scope.currentUser.id + '&from=' + $scope.chatPartner.id,
        }).success(function (data) {
            $scope.messages = data;
        });
    }

    function listenForNewMessages() {
        $interval(function () {
            refreshData();
        }, 5000);
    }
    listenForNewMessages();
});

