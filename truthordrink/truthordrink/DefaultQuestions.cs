using System;
using System.Collections.Generic;
using System.Text;
using truthordrink.Model;

namespace truthordrink
{
    public class DefaultQuestions
    {
        private static List<string> questions = new List<string>()
        {
            "Do you think double texting is a big deal?",
            "What's the most embarrassing thing you've ever done to get a crush's attention?",
            "When did you have your first kiss?",
            "Do you believe in astrology? Does your sign fit you?",
            "What's the most spontaneous thing you've ever done?",
            "If you go to a restaurant and have terrible service, is it ever OK not to tip?",
            "Have you ever cheated on your S.O.?",
            "Have you ever been cheated on?",
            "What's your biggest regret?",
            "What's your dream date night?",
            "How many S.O.s have you had?",
            "Are you looking for a relationship?",
            "What do you consider a red flag in a relationship?",
            "What is your love language?",
            "If your life was a movie, what would it be called?",
            "What was the last concert you went to?",
            "What do you wish you were really good at?",
            "If you were a dog, what kind of dog would you be?",
            "Do you believe in aliens?",
            "Do you shower at night or in the morning?",
            "What's the most cringeworthy outfit you've ever worn?",
            "If you could be any animal, what would you be?",
            "If you had to rename yourself, what name would you choose?",
            "What was the last show you binge-watched?",
            "What is the worst lie you've ever told your parents?",
            "If any actor or actress could play you in a movie, who would it be?",
            "What's your favorite song lyric?",
            "When was the last time you felt most yourself?",
            "What do you think my superpower is?",
            "What is your dream job?",
            "What does your ideal weekend look like?",
            "What is something that people misunderstand about you?",
            "What is something that you would change about your life?",
            "What do you think is your best quality?",
            "What are you most scared of?",
            "How many people have you kissed?",
            "Do you ever think about me?",
            "What have you done sexually with someone else?",
            "What attracts you to people?",
            "What are your thoughts on sex?",
            "Are you a virgin?",
            "Do you think you're a good kisser?",
            "What turns you on?",
            "Have you ever had a sexy dream?",
            "What do you wear when you sleep?",
            "What is the worst assumption someone has made about you?",
            "Have you ever been in love?",
            "Have you ever snuck out of the house? For what?",
            "How did your last relationship end?",
            "What was your first impression of me?",
            "What is the weirdest dream you've ever had?",
            "What is on your bucket list?",
            "Are you more of a morning or night person?",
            "What is your go-to karaoke song?",
            "If you could move anywhere in the world, where would you go?",
            "What was one time you really stepped out of your comfort zone?",
            "What is the biggest lesson you've learned?",
            "What is your favorite movie of all time?",
            "What is your biggest guilty pleasure?",
            "If you were a superhero, what kind of secret identity would you have?",
            "What would your younger self not believe about your life today?",
            "If you won the lottery, what would you do with the money?",
            "What three items would you bring with you to a deserted island?",
            "Who is the last person you texted?",
            "What is the last thing you searched for on your phone?",
            "Who is your celebrity crush?",
            "What is the one thing you can't live without?"
        };
        public static void AddDefaultQuestions()
        {
            if (!App.IsAuthenticated()) return;
            foreach (string strQuestion in questions)
            {
                Question question = new Question
                {
                    userId = App.GetAuthenticatedUserId(),
                    question = strQuestion,
                };
                App.Database.SaveQuestionAsync(question);
            }
        }
    }
}
