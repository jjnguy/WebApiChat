app.controller('ChatPage', function ($scope, $http) {

    $scope.chats = [];

    $scope.newChatUser = 'not jjnguy';

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
            $scope.currentBody = ''
        });
    };

    $scope.poll = true;
    $scope.togglePollChar = function () {
        return $scope.poll ? 'X' : '0';
    };
    $scope.togglePolling = function () {
        $scope.poll = !$scope.poll;
    };

    function refreshData() {
        $http({
            method: 'GET',
            url: '/api/messages?to=' + $scope.currentUser.id + '&from=' + $scope.chatPartner.id,
        }).success(function (data) {
            if ($scope.messages.length != data.length) {
                $scope.messages = data;
            }
        });
    }

    function listenForNewMessages() {
        $interval(function () {
            if ($scope.poll) {
                refreshData();
            }
        }, 1000);
    }
    listenForNewMessages();
});

