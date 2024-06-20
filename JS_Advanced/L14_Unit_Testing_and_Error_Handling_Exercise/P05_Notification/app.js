function notify(message) {

    const notificationEl = document.getElementById('notification');
    notificationEl.textContent = message;
    notificationEl.style.display = 'block';

    notificationEl.addEventListener('click', () => {
        notificationEl.style.display = 'none';
    });

}