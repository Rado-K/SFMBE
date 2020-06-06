window.tokenManager = {
    save: function (token) {
        window.localStorage.setItem('jwt', token);
        console.log("Authentication token has been stored.");
        return true;
    },
    read: function () {
        var token = window.localStorage.getItem('jwt');
        console.log(token ? "Authentication token read from storage." : "No authentication token found in storage.");
        return token;
    },
    delete: function () {
        window.localStorage.removeItem('jwt');
        console.log("Authentication token has been deleted.");
        return true;
    }
};

window.storageManager = {
    save: function (key, data) {
        window.localStorage.setItem(key, data);
        return true;
    },
    read: function (key) {
        var value = window.localStorage.getItem(key);
        return value;
    },
    delete: function (key) {
        window.localStorage.removeItem(key);
        return true;
    }
};
