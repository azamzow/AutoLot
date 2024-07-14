var skimedicInterop = {};
skimedicInterop.setLocalStorage = function (key, data) {
    //scoped to browser window
    localStorage.setItem(key, data);
}
skimedicInterop.getLocalStorage = function (key) {
    return localStorage.getItem(key);
}
skimedicInterop.setSessionStorage = function (key, data) {
    //scoped to browser tab
    sessionStorage.setItem(key, data);
}
skimedicInterop.getSessionStorage = function (key) {
    return sessionStorage.getItem(key);
}