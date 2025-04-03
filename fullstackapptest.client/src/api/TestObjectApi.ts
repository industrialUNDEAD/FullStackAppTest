export interface TestObject {
    code: number;
    value: string;
}

export async function fetchTestObjects(): Promise<TestObject[]> {
    const response = await fetch('http://localhost:5278/api/TestObject', {
        mode: 'cors'
    });

    const json = await response.json();

    return json;
}