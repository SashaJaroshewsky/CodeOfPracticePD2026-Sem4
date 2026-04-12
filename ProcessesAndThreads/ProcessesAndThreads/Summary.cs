namespace ProcessesAndThreads
{
    internal class Summary
    {
        // Process - Ізольований простір пам'яті
        //    | 
        //    | Thread - Мінімум один або декілька
        //         |
        //         | - Foreground / Background
        //         | - Власний Stack
        //         | - Спільна пам'ять з іншими потоками - потребує синхронізації


        // Інструменти:

        // Thread          — низький рівень, ручне керування
        // ThreadPool      — пул готових потоків
        // Task            — абстракція, сучасний підхід
        // async/await     — неблокуюче очікування

        //  Синхронізація:
        //      lock            — ексклюзивний доступ
        //      Interlocked     — атомарні операції

        //      SemaphoreSlim   — обмежений паралельний доступ
        //      CancellationToken — скасування

        // Це приблизно 80% практичних потреб даної теми

        // Для повного освоєння теми потрібно освоїти:

        // async/await під капотом — State Machine, ConfigureAwait
        // Deadlock — як виникає і як уникнути
        // Parallel клас — Parallel.For, Parallel.ForEach
        // Channel<T> — сучасна черга між потоками
        // Mutex, Monitor, ReaderWriterLock — просунута синхронізація
    }
}
