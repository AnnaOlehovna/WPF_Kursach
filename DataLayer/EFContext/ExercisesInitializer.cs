using DataLayer.Entities;
using System.Data.Entity;

namespace DataLayer.EFContext
{
    internal class ExercisesInitializer : CreateDatabaseIfNotExists<ExercisesContext>
    {
        protected override void Seed(ExercisesContext context)
        {
            context.Exercises.AddRange(new Exercise[]{
                new Exercise
                {
                   Name = "Растяжка спины",
                   Description = "Эта растяжка также известна как ромбовидная растяжка верхней части спины.\n" +
                   "1. Сцепите руки перед собой и опустите голову на одном уровне с руками.\n" +
                   "2. Потянитесь вперед и удерживайтесь в таком положении от 10 до 30 секунд.",
                   LastUsedTime = 0,
                   ImageUri = "/Resources/Forward_Stretch.gif"

                },
                 new Exercise
                {
                     Name = "Растяжка подколенных сухожилий",
                   Description = "1. Сядьте на стул, вытяните одну ногу вперед.\n" +
                   "2. Потянитесь к пальцам ног.\n" +
                   "3. Задержитесь на 10 - 30 секунд.\n" +
                   "4. Повторите с другой стороны.\n" +
                   "Обязательно выполняйте это упражнение по одной ноге, поскольку выполнение этого упражнения с двумя вытянутыми ногами может вызвать проблемы со спиной.",
                   LastUsedTime = 0,
                   ImageUri = "/Resources/Hamstring_Stretch.gif"

                },
                 new Exercise
                {
                   Name = "Растяжка шеи",
                   Description = "1. Расслабьтесь и наклоните голову вперед.\n" +
                   "2. Медленно перекатите голову в одну сторону и удерживайте 10 секунд.\n" +
                   "3. Повторите с другой стороны.\n" +
                   "4. Снова расслабьтесь и верните подбородок в исходное положение.",
                   LastUsedTime = 0,
                   ImageUri = "/Resources/Neck_Stretch.gif"

                },
                  new Exercise
                {
                   Name = "Растяжка широчайшей мышцы",
                   Description = "1. Вытяните руку над головой.\n" +
                   "2. Наклонитесь в противоположную сторону.\n" +
                   "3. Задержитесь на 10 - 30 секунд.\n" +
                   "4. Повторите с другой стороны.",
                   LastUsedTime = 0,
                   ImageUri = "/Resources/Overhead_Reach.gif"

                },
                  new Exercise
                {
                   Name = "Растяжка плеча и грудной мышцы",
                   Description = "1. Сложите руки за спину.\n" +
                   "2. Вытолкните грудь наружу и поднимите подбородок.\n" +
                   "3. Задержитесь на 10 - 30 секунд.",
                   LastUsedTime = 0,
                   ImageUri = "/Resources/Shoulder_Pec_Stretch.gif"

                },
                  new Exercise
                {
                   Name = "Пожатие плечами",
                   Description = "1. Поднимите оба плеча к ушам.\n" +
                   "2. Сросьте их вниз и повторите.",
                   LastUsedTime = 0,
                   ImageUri = "/Resources/Shoulder_Shrug.gif"

                },
                  new Exercise
                {
                   Name = "Растяжка туловища",
                   Description = "1. Сядьте на стул. Держите ноги твердо на земле, лицом вперед.\n" +
                   "2. Закиньте одну ногу на другую. Одноименную руку положите на спинку стула.\n" +
                   "3. Поверните верхнюю часть тела в направлении руки, опирающейся на спинку стула.\n"+
                   "4. Задержитесь на 10 - 30 секунд.\n"+
                   "5. Повторите с другой стороны.",
                   LastUsedTime = 0,
                   ImageUri = "/Resources/Torso_Stretch.gif"

                },
                  new Exercise
                {
                   Name = "Растяжка на трицепс",
                   Description = "1. Поднимите руку и согните ее за спину так, чтобы ваша рука потянулась к противоположной стороне.\n" +
                   "2. Другой рукой потяните локоть к голове.\n" +                   
                   "3. Задержитесь на 10 - 30 секунд.\n"+
                   "4. Повторите с другой стороны.",
                   LastUsedTime = 0,
                   ImageUri = "/Resources/Triceps_Stretch.gif"

                },
                   new Exercise
                {
                   Name = "Растяжка верхней части тела и рук",
                   Description = "1. Сложите руки вместе над головой ладонями наружу.\n" +
                   "2. Поднимите руки вверх, потянувшись вверх.\n" +
                   "3. Задержитесь на 10 - 30 секунд.",
                   LastUsedTime = 0,
                   ImageUri = "/Resources/Upper_Body_Stretch.gif"
                },
                   new Exercise
                {
                   Name = "Растяжка верхней части тела и рук",
                   Description = "1. Положите руку на голову.\n" +
                   "2. Осторожно потяните голову к плечу, пока не почувствуете легкое растяжение.\n" +
                   "3. Задержитесь на 10 - 15 секунд.\n"+
                   "4. Повторите с другой стороны.",
                   LastUsedTime = 0,
                   ImageUri = "/Resources/Upper_Trap_Stretch.gif"
                }
            });
        }
    }
}
