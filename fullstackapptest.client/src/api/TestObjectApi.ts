export interface TestObject {
    code: number;
    value: string;
}

export async function fetchTestObjects(): Promise<TestObject[]> {
    const response = await fetch('/api/TestObject');

    console.log('RESPONSE STATUS:', response.status);
    const json = await response.json();
    console.log('онксвеммше дюммше:', json);

    return json;
}