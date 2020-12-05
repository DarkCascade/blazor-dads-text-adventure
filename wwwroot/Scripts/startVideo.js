function startVideo() {
    var video = document.getElementById('video');

    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
        navigator.mediaDevices.getUserMedia({ video: true }).then(function (stream) {
            try {
                video.srcObject = stream;
            } catch (e) {
                video.src = window.URL.createObjectURL(stream);
            }            
            
            video.play();
        });
    }
}
