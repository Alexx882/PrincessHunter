# Princess death
ffmpeg -i princesses.m4a -ss 0.5 -to 1.5 -c:v copy -c:a libmp3lame death-sound-princess-1.mp3

ffmpeg -i princesses.m4a -ss 4 -to 5 -c:v copy -c:a libmp3lame death-sound-princess-2.mp3

ffmpeg -i princesses.m4a -ss 5.5 -to 6.5 -c:v copy -c:a libmp3lame death-sound-princess-3.mp3

ffmpeg -i princesses.m4a -ss 10.2 -to 11.2 -c:v copy -c:a libmp3lame death-sound-princess-4.mp3

# Dragon death
ffmpeg -i princesses.m4a -ss 13.2 -to 14.2 -c:v copy -c:a libmp3lame death-sound-dragon-1.mp3

ffmpeg -i princesses.m4a -ss 15.8 -to 16.8 -c:v copy -c:a libmp3lame death-sound-dragon-2.mp3

# Background sound
ffmpeg -i originals/sounds-2.m4a -ss 3 -to 4 -c:v copy -c:a libmp3lame death-sound-dragon-3.mp3

ffmpeg -i originals/sounds-2.m4a -ss 0.8 -to 1.8 -c:v copy -c:a libmp3lame death-sound-dragon-4.mp3

# Start sound
ffmpeg -i originals/sounds-2.m4a -ss 9.3 -to 10.45 -c:v copy -c:a libmp3lame start-sound.mp3

