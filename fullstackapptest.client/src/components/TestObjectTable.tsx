import { useEffect, useState } from 'react';
import { fetchTestObjects, TestObject } from '../api/TestObjectApi';

const PAGE_SIZE = 5;

export const TestObjectTable = () => {
    const [objects, setObjects] = useState<TestObject[]>([]);
    const [currentPage, setCurrentPage] = useState(1);

    useEffect(() => {
        fetchTestObjects()
            .then((data) => {
                setObjects(data);
            })
            .catch((error) => {
                console.error('Ошибка загрузки данных:', error);
            });
    }, []);

    const startIndex = (currentPage - 1) * PAGE_SIZE;
    const paginated = objects.slice(startIndex, startIndex + PAGE_SIZE);

    const handleNext = () => {
        if (startIndex + PAGE_SIZE < objects.length) {
            setCurrentPage((p) => p + 1);
        }
    };

    const handlePrev = () => {
        if (currentPage > 1) {
            setCurrentPage((p) => p - 1);
        }
    };

    return (
        <div style={{ padding: '2rem' }}>
            <h2>Список TestObject</h2>
            <table border={1} cellPadding={5} style={{ marginTop: '1rem' }}>
                <thead>
                    <tr>
                        <th>Code</th>
                        <th>Value</th>
                    </tr>
                </thead>
                <tbody>
                    {paginated.map((obj, i) => (
                        <tr key={i}>
                            <td>{obj.code}</td>
                            <td>{obj.value}</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <div style={{ marginTop: '1rem' }}>
                <button onClick={handlePrev} disabled={currentPage === 1}>
                    ← Назад
                </button>
                <span style={{ margin: '0 1rem' }}>Страница: {currentPage}</span>
                <button
                    onClick={handleNext}
                    disabled={startIndex + PAGE_SIZE >= objects.length}
                >
                    Вперёд →
                </button>
            </div>
        </div>
    );
};
